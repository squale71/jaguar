using Discord_Bot_Application.App_Start;
using Microsoft.Extensions.Configuration;
using System;

namespace Discord_Bot_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.Initialize().GetAwaiter().GetResult();
        }
    }
}
