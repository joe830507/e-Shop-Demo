using e_Shop_Demo.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace e_Shop_Demo.Extensions
{
    public static class ControllerBaseExtensions
    {
        public static object GetToken(this ControllerBase controller, IConfiguration Configuration, List<Claim> claims, DateTime expires)
        {
            var tokenConfiguration = Configuration.GetSection("Security:Token");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguration["Key"]));
            var signCredential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(
                issuer: tokenConfiguration["Issuer"],
                audience: tokenConfiguration["Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: signCredential);
            return new
            {
                token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                expiration = TimeZoneInfo.ConvertTimeFromUtc(jwtToken.ValidTo, TimeZoneInfo.Local).ToString("yyyy-MM-dd hh:mm:ss")
            };
        }

        public static object GetToken(this ControllerBase controller, IConfiguration Configuration, List<Claim> claims)
        {
            return GetToken(controller, Configuration, claims, DateTime.Now.AddHours(2));
        }

        public static object GetPagination<T>(this ControllerBase controller, IEnumerable<T> pagedList)
        {
            PagedList<T> pageInfo = (PagedList<T>)pagedList;
            var paginationMetadata = new
            {
                totalCount = pageInfo.TotalCount,
                pageSize = pageInfo.PageSize,
                currentPage = pageInfo.CurrentPage,
                totalPages = pageInfo.TotalPages
            };
            return paginationMetadata;
        }
    }
}
