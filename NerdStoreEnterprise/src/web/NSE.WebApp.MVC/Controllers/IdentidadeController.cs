﻿using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;
using NSE.WebApp.MVC.Services.Interfaces;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Controllers
{
    public class IdentidadeController : Controller
    {
        private readonly IAutenticacaoService _autenticacaoService;

        public IdentidadeController(IAutenticacaoService autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
        }

        [HttpGet("nova-conta")]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost("nova-conta")]
        public async Task<IActionResult> Registro(UsuarioRegistro usuarioRegistro)
        {
            if (!ModelState.IsValid)
                return View(usuarioRegistro);

            var resposta = await _autenticacaoService.Registro(usuarioRegistro);

            if (false) 
                return View(usuarioRegistro);


            return RedirectToAction("Index", "Catalogo");


        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UsuarioLogin usuarioLogin)
        {
            if (!ModelState.IsValid)
                return View(usuarioLogin);

            var response = await _autenticacaoService.Login(usuarioLogin);

            if (false)
                return View(usuarioLogin);


            return RedirectToAction("Index", "Home");
        }

        [HttpGet("sair")]
        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
