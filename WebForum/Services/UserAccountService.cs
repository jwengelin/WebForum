using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebForum.Models.DB;
using WebForum.Filters;


namespace WebForum.Services
{
    public class UserAccountService
    {
        private WebForumDBContext db;
        private Roles roles;
        private string key;

        public UserAccountService(WebForumDBContext _db, IConfiguration config)
        {
            db = _db;
            key = config.GetValue<string>("Keys:SecretKey");
            db = _db;
            Roles _roles = new Roles();
            roles = _roles;
        }       

        public bool LoginUser(string accountNameInput, string accountPasswordInput) // Login
        {
            string salt;
            string passwordInDb;
            string hashedPassword;
            bool loginOk = false;
            try
            {
                salt = GetUserSalt(accountNameInput); // Get salt from DB with UserAccountName
                if (salt is null)
                {
                    return loginOk = false;
                }
                passwordInDb = GetPassword(accountNameInput); // Gets hashed password from DB
                hashedPassword = HashPassword(salt, accountPasswordInput); // Concatenates password input and salt and runs algorithm
            }
            catch
            {
                return loginOk; // returns false bool if operations above fails
            }
            if (passwordInDb.Equals(hashedPassword)) // if hashed input password equals hashed password from database, LoginOk becomes true
            {
                return loginOk = true;
            }
            return loginOk;
        }

        public string GetPassword(string accountName) // Gets password from DB
        {           
                var password = db.UserAccounts
                              .Where(s => s.AccountName == accountName)
                              .Select(s => s.AccountPassword)
                              .FirstOrDefault()
                              .ToString();
                return password;         
        }

        public string GetUserSalt(string accountNameInput) // Gets salt from DB
        {
            
                var salt = (from s in db.UserAccounts
                            where s.AccountName == accountNameInput
                            select s.Salt).First().ToString();
                
                return salt;
        }
        
        public UserAccounts RegisterUser(string accountName, string accountPassword)
        {           
            string newSalt = CreateSalt(10); // Calls Create salt function
            string hashedPass = HashPassword(newSalt, accountPassword); // Calls hashpassword function 
            int roleId = GetRoleId("USER"); // hardcoded at the moment
            UserAccounts user = new UserAccounts();
            user.AccountName = accountName;
            user.AccountPassword = hashedPass;
            user.Salt = newSalt;
            user.RoleId = roleId;
            return user;
        }

        public int GetRoleId (string roleName)
        {
            var roleId = (from s in db.UserRoles
                          where s.Role == roleName
                          select s.RoleId).First();
            
            return roleId;
        }

        public UserAccounts GetUser(string accountName) // Gets password from DB
        {
            var user = (from p in db.UserAccounts
                        where p.AccountName == accountName
                        select p).FirstOrDefault<UserAccounts>();

            return user;
        }

        private static string CreateSalt(int size) // Creates salt
        {
            //Generate a cryptographic random number.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number.
            return Convert.ToBase64String(buff);
        }

        public string HashPassword(string salt, string password) // Concatenates salt and password
        {
            string mergedPass = string.Concat(salt, password);
            return Sha256(mergedPass);
        }

        private string Sha256(string randomString) // Hashes salted password
        {
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
        public string GetRole (int? roleId)
        {
            var role = (from s in db.UserRoles
                          where s.RoleId == roleId
                          select s.Role).First().ToString();

            return role;
        }

        public List<Claim> GetClaims(UserAccounts user)
        {
            var userRole = GetRole(user.RoleId);
            var roleType = roles.GetRole(userRole);
            IdentityOptions _options = new IdentityOptions();
            var claims = new List<Claim>
            {
                new Claim(_options.ClaimsIdentity.UserIdClaimType, user.UserAccountId.ToString()),
                new Claim(_options.ClaimsIdentity.UserNameClaimType, user.AccountName),
                //new Claim(_options.ClaimsIdentity.RoleClaimType, userRole),
                new Claim(roleType, userRole)
            };
            return claims;
        }


        public string CreateToken(string accountName)
        {
            var user = GetUser(accountName);
            byte[] secretKey = Encoding.ASCII.GetBytes(key);

            var JWToken = new JwtSecurityToken(
            issuer: "https://localhost:44319/",
            audience: "https://localhost:44319/",
            claims: GetClaims(user),
            notBefore: new DateTimeOffset(DateTime.Now).DateTime,
            expires: new DateTimeOffset(DateTime.Now.AddHours(1)).DateTime,
            //Using HS256 Algorithm to encrypt Token
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secretKey),
                                SecurityAlgorithms.HmacSha256Signature)
        );
            var token = new JwtSecurityTokenHandler().WriteToken(JWToken);

            return token;
        }
    }
}
