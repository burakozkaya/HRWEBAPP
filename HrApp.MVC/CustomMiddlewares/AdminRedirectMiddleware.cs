﻿using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

public class AdminRedirectMiddleware
{
    private readonly RequestDelegate _next;

    public AdminRedirectMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Kullanıcı giriş yapmışsa
        if (context.User.Identity.IsAuthenticated)
        {
            // Kullanıcı 'Admin' rolünde mi kontrol et
            if (context.User.FindFirstValue("role").ToLower().Contains("admin"))
            {
                // Eğer kullanıcı zaten Admin alanında değilse, Admin alanına yönlendir
                if (!context.Request.Path.StartsWithSegments("/Admin"))
                {
                    context.Response.Redirect("/Admin");
                    return;
                }
            }
        }

        // Sonraki middleware'e geç
        await _next(context);
    }
}
