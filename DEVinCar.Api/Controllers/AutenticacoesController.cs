using DEVinCar.Api.Services;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Models;
using DEVinCar.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace DEVinCar.Api.Controllers
{
    public class AutenticacoesController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<AutenticacoesController> _logger;
        public AutenticacoesController(IUserRepository userRepository, ILogger<AutenticacoesController> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult EfetuarLogin([FromBody] LoginRequisicaoDTO loginrequisicao)
        {
            try
            {
                if (!String.IsNullOrEmpty(loginrequisicao.Email) && !String.IsNullOrEmpty(loginrequisicao.Email) &&
                    !String.IsNullOrWhiteSpace(loginrequisicao.Password) && !String.IsNullOrWhiteSpace(loginrequisicao.Password))
                {
                    User user = _userRepository.ObterPorEmail(loginrequisicao.Email.ToLower());

                    if (user != null)
                    {
                        var token = TokenService.GenerateTokenFromUser(user);
                        var refreshToken = TokenService.GenerateRefreshToken();
                        TokenService.SaveRefreshToken(user.Name, refreshToken);

                        return Ok(new
                        {
                            token,
                            refreshToken
                        });

                    }

                    else
                    {
                        return BadRequest(new ErrorDTO()
                        {
                            Error = "Email ou sennha inválido!",
                            Status = StatusCodes.Status400BadRequest
                        });
                    }
                }
                else
                {
                    return BadRequest(new ErrorDTO()
                    {
                        Error = "Campos não preenchidos corretamente",
                        Status = StatusCodes.Status400BadRequest

                    });

                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocorreu erro no login" + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorDTO()
                {
                    Error = "Ocorreu um erro ao efetuar login",
                    Status = StatusCodes.Status500InternalServerError

                }); ;

            }
        }

        [HttpPost]
        [Route("refresh")]
        [AllowAnonymous]
        public IActionResult RefreshToken([FromQuery] string token, [FromQuery] string refreshToken)
        {
            var principal = TokenService.GetPrincipalFromExpiredToken(token);
            var username = principal.Identity.Name;
            var savedRefreshToken = TokenService.GetRefreshToken(username);

            if (savedRefreshToken != refreshToken)
                throw new SecurityTokenException("Invalid refresh token");

            var newToken = TokenService.GenerateTokenFromClaims(principal.Claims);
            var newRefreshToken = TokenService.GenerateRefreshToken();
            TokenService.DeleteRefreshToken(username, refreshToken);
            TokenService.SaveRefreshToken(username, newRefreshToken);

            return new ObjectResult(new
            {
                token = newToken,
                refreshToken = newRefreshToken

            });

        }

        [HttpGet]
        [Route("list-refresh-tokens")]
        public IActionResult ListRefreshTokens()
        {
            return Ok(TokenService.GetAllRefreshTokens());
        }

    }
}
