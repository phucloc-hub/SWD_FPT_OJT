using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SWD_DEMO.Constants;
using SWD_DEMO.DTOS;
using SWD_DEMO.Models;
using SWD_DEMO.Services;

namespace SWD_DEMO.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        private readonly IAccountService _service;

        private IConfiguration configuration;
        /*private readonly IMapper _mapper;*/
        private readonly SWDContext _context;

        public AccountsController(IConfiguration configuration,IAccountService service, SWDContext context)
        {
            this.configuration = configuration;
            _service = service;
            _context = context;
        }



        // GET api/jobs
        [HttpGet]
        public IActionResult Get()
        {
            var result = _service.GetAllAccount();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

    

        [HttpGet("{email}")]
        public IActionResult GetAccountByEmail(string email)
        {
            var result = _service.GetByID(email);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }


        [HttpPut ("{email}")]
        public IActionResult UpdateAccountByEmail(string email, [FromBody] Account accountDTO)
        {
            /*     var account = _mapper.Map<Account>(accountDTO);// mapping object to a row in db
                 if(_id != account.Code)
                 {
                     return BadRequest();
                 }*/
           /* var config = new MapperConfiguration(cfg => cfg.CreateMap<AccountDTO, Account>());
            var mapper = new Mapper(config);
            var dto = mapper.Map<Account>(accountDTO);*/

  


            var accountCheckingExist = _service.GetAccountByEmail(email);
            if(accountCheckingExist != null)
            {
                var rs=  _service.UpdateAccount(accountDTO);
                try
                {
                    this._context.Account.Update(rs);
                    this._context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IsExistAccount(email))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return NoContent();
          
        }
        // POST: AccountsController/Create
        [HttpPost]
        public IActionResult Post([FromBody] Account _entity)
        {
            _service.CreateAccount(_entity);
            _service.Commit();
            return Created("Get", _entity);
        }

        /*[Authorize(ConstantRegister.RoleAd == HttpContext.User.Identity.)]*/
        [HttpDelete("{email}")]
        public IActionResult DeleteAccountByID(string email)
        {
            var account = _service.GetAccountByEmail(email);
            if(account != null)
            {
                _service.DeleteAccount(email);
                _service.Commit();
                return Ok(account);
            }
            else
            {
                return NotFound();
            }
        }

        private string GenerateJSONWebToken(Account accountInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email,accountInfo.Email),
                new Claim(ConstantRegister.RoleKey,accountInfo.Role)
            };
            var token = new JwtSecurityToken(

                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
            );
            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;

        }




      
        private bool IsExistAccount(string email)
        {
            return _context.Account.Any(e => e.Email == email);
        }
    }
}
