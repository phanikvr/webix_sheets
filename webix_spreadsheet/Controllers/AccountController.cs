using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace webix_spreadsheet.Controllers
{
    [RoutePrefix("api/Account")]
    [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
    public class AccountController : ApiController
    {
        //private const string LocalLoginProvider = "Local";
        //private ApplicationUserManager _userManager;

        //public AccountController()
        //{
        //}

        //public AccountController(ApplicationUserManager userManager,
        //    ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        //{
        //    UserManager = userManager;
        //    AccessTokenFormat = accessTokenFormat;
        //}

        //public ApplicationUserManager UserManager
        //{
        //    get
        //    {
        //        return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    }
        //    private set
        //    {
        //        _userManager = value;
        //    }
        //}

        //public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

        //// GET api/Account/UserInfo
        //[HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        //[Route("UserInfo")]
        //public UserInfoViewModel GetUserInfo()
        //{
        //    ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

        //    return new UserInfoViewModel
        //    {
        //        Email = User.Identity.GetUserName(),
        //        HasRegistered = externalLogin == null,
        //        LoginProvider = externalLogin != null ? externalLogin.LoginProvider : null
        //    };
        //}

        //// POST api/Account/Logout
        //[Route("Logout")]
        //public IHttpActionResult Logout()
        //{
        //    Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
        //    return Ok();
        //}

        //// GET api/Account/ManageInfo?returnUrl=%2F&generateState=true
        //[Route("ManageInfo")]
        //public async Task<ManageInfoViewModel> GetManageInfo(string returnUrl, bool generateState = false)
        //{
        //    IdentityUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

        //    if (user == null)
        //    {
        //        return null;
        //    }

        //    List<UserLoginInfoViewModel> logins = new List<UserLoginInfoViewModel>();

        //    foreach (IdentityUserLogin linkedAccount in user.Logins)
        //    {
        //        logins.Add(new UserLoginInfoViewModel
        //        {
        //            LoginProvider = linkedAccount.LoginProvider,
        //            ProviderKey = linkedAccount.ProviderKey
        //        });
        //    }

        //    if (user.PasswordHash != null)
        //    {
        //        logins.Add(new UserLoginInfoViewModel
        //        {
        //            LoginProvider = LocalLoginProvider,
        //            ProviderKey = user.UserName,
        //        });
        //    }

        //    return new ManageInfoViewModel
        //    {
        //        LocalLoginProvider = LocalLoginProvider,
        //        Email = user.UserName,
        //        Logins = logins,
        //        ExternalLoginProviders = GetExternalLogins(returnUrl, generateState)
        //    };
        //}

        //// POST api/Account/ChangePassword
        //[Route("ChangePassword")]
        //public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    IdentityResult result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword,
        //        model.NewPassword);

        //    if (!result.Succeeded)
        //    {
        //        return GetErrorResult(result);
        //    }

        //    return Ok();
        //}

        //// POST api/Account/SetPassword
        //[Route("SetPassword")]
        //public async Task<IHttpActionResult> SetPassword(SetPasswordBindingModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    IdentityResult result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);

        //    if (!result.Succeeded)
        //    {
        //        return GetErrorResult(result);
        //    }

        //    return Ok();
        //}

        //// POST api/Account/AddExternalLogin
        //[Route("AddExternalLogin")]
        //public async Task<IHttpActionResult> AddExternalLogin(AddExternalLoginBindingModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);

        //    AuthenticationTicket ticket = AccessTokenFormat.Unprotect(model.ExternalAccessToken);

        //    if (ticket == null || ticket.Identity == null || (ticket.Properties != null
        //        && ticket.Properties.ExpiresUtc.HasValue
        //        && ticket.Properties.ExpiresUtc.Value < DateTimeOffset.UtcNow))
        //    {
        //        return BadRequest("External login failure.");
        //    }

        //    ExternalLoginData externalData = ExternalLoginData.FromIdentity(ticket.Identity);

        //    if (externalData == null)
        //    {
        //        return BadRequest("The external login is already associated with an account.");
        //    }

        //    IdentityResult result = await UserManager.AddLoginAsync(User.Identity.GetUserId(),
        //        new UserLoginInfo(externalData.LoginProvider, externalData.ProviderKey));

        //    if (!result.Succeeded)
        //    {
        //        return GetErrorResult(result);
        //    }

        //    return Ok();
        //}

        //// POST api/Account/RemoveLogin
        //[Route("RemoveLogin")]
        //public async Task<IHttpActionResult> RemoveLogin(RemoveLoginBindingModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    IdentityResult result;

        //    if (model.LoginProvider == LocalLoginProvider)
        //    {
        //        result = await UserManager.RemovePasswordAsync(User.Identity.GetUserId());
        //    }
        //    else
        //    {
        //        result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(),
        //            new UserLoginInfo(model.LoginProvider, model.ProviderKey));
        //    }

        //    if (!result.Succeeded)
        //    {
        //        return GetErrorResult(result);
        //    }

        //    return Ok();
        //}

        //// GET api/Account/ExternalLogin
        //[OverrideAuthentication]
        //[HostAuthentication(DefaultAuthenticationTypes.ExternalCookie)]
        //[AllowAnonymous]
        //[Route("ExternalLogin", Name = "ExternalLogin")]
        //public async Task<IHttpActionResult> GetExternalLogin(string provider, string error = null)
        //{
        //    if (error != null)
        //    {
        //        return Redirect(Url.Content("~/") + "#error=" + Uri.EscapeDataString(error));
        //    }

        //    if (!User.Identity.IsAuthenticated)
        //    {
        //        return new ChallengeResult(provider, this);
        //    }

        //    ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(User.Identity as ClaimsIdentity);

        //    if (externalLogin == null)
        //    {
        //        return InternalServerError();
        //    }

        //    if (externalLogin.LoginProvider != provider)
        //    {
        //        Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
        //        return new ChallengeResult(provider, this);
        //    }

        //    ApplicationUser user = await UserManager.FindAsync(new UserLoginInfo(externalLogin.LoginProvider,
        //        externalLogin.ProviderKey));

        //    bool hasRegistered = user != null;

        //    if (hasRegistered)
        //    {
        //        Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);

        //         ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(UserManager,
        //            OAuthDefaults.AuthenticationType);
        //        ClaimsIdentity cookieIdentity = await user.GenerateUserIdentityAsync(UserManager,
        //            CookieAuthenticationDefaults.AuthenticationType);

        //        AuthenticationProperties properties = ApplicationOAuthProvider.CreateProperties(user.UserName);
        //        Authentication.SignIn(properties, oAuthIdentity, cookieIdentity);
        //    }
        //    else
        //    {
        //        IEnumerable<Claim> claims = externalLogin.GetClaims();
        //        ClaimsIdentity identity = new ClaimsIdentity(claims, OAuthDefaults.AuthenticationType);
        //        Authentication.SignIn(identity);
        //    }

        //    return Ok();
        //}

        //// GET api/Account/ExternalLogins?returnUrl=%2F&generateState=true
        //[AllowAnonymous]
        //[Route("ExternalLogins")]
        //public IEnumerable<ExternalLoginViewModel> GetExternalLogins(string returnUrl, bool generateState = false)
        //{
        //    IEnumerable<AuthenticationDescription> descriptions = Authentication.GetExternalAuthenticationTypes();
        //    List<ExternalLoginViewModel> logins = new List<ExternalLoginViewModel>();

        //    string state;

        //    if (generateState)
        //    {
        //        const int strengthInBits = 256;
        //        state = RandomOAuthStateGenerator.Generate(strengthInBits);
        //    }
        //    else
        //    {
        //        state = null;
        //    }

        //    foreach (AuthenticationDescription description in descriptions)
        //    {
        //        ExternalLoginViewModel login = new ExternalLoginViewModel
        //        {
        //            Name = description.Caption,
        //            Url = Url.Route("ExternalLogin", new
        //            {
        //                provider = description.AuthenticationType,
        //                response_type = "token",
        //                client_id = Startup.PublicClientId,
        //                redirect_uri = new Uri(Request.RequestUri, returnUrl).AbsoluteUri,
        //                state = state
        //            }),
        //            State = state
        //        };
        //        logins.Add(login);
        //    }

        //    return logins;
        //}

        //// POST api/Account/Register
        //[AllowAnonymous]
        //[Route("Register")]
        //public async Task<IHttpActionResult> Register(RegisterBindingModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };

        //    IdentityResult result = await UserManager.CreateAsync(user, model.Password);

        //    if (!result.Succeeded)
        //    {
        //        return GetErrorResult(result);
        //    }

        //    return Ok();
        //}

        //// POST api/Account/RegisterExternal
        //[OverrideAuthentication]
        //[HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        //[Route("RegisterExternal")]
        //public async Task<IHttpActionResult> RegisterExternal(RegisterExternalBindingModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var info = await Authentication.GetExternalLoginInfoAsync();
        //    if (info == null)
        //    {
        //        return InternalServerError();
        //    }

        //    var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };

        //    IdentityResult result = await UserManager.CreateAsync(user);
        //    if (!result.Succeeded)
        //    {
        //        return GetErrorResult(result);
        //    }

        //    result = await UserManager.AddLoginAsync(user.Id, info.Login);
        //    if (!result.Succeeded)
        //    {
        //        return GetErrorResult(result); 
        //    }
        //    return Ok();
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && _userManager != null)
        //    {
        //        _userManager.Dispose();
        //        _userManager = null;
        //    }

        //    base.Dispose(disposing);
        //}

        //#region Helpers

        //private IAuthenticationManager Authentication
        //{
        //    get { return Request.GetOwinContext().Authentication; }
        //}

        //private IHttpActionResult GetErrorResult(IdentityResult result)
        //{
        //    if (result == null)
        //    {
        //        return InternalServerError();
        //    }

        //    if (!result.Succeeded)
        //    {
        //        if (result.Errors != null)
        //        {
        //            foreach (string error in result.Errors)
        //            {
        //                ModelState.AddModelError("", error);
        //            }
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            // No ModelState errors are available to send, so just return an empty BadRequest.
        //            return BadRequest();
        //        }

        //        return BadRequest(ModelState);
        //    }

        //    return null;
        //}

        //private class ExternalLoginData
        //{
        //    public string LoginProvider { get; set; }
        //    public string ProviderKey { get; set; }
        //    public string UserName { get; set; }

        //    public IList<Claim> GetClaims()
        //    {
        //        IList<Claim> claims = new List<Claim>();
        //        claims.Add(new Claim(ClaimTypes.NameIdentifier, ProviderKey, null, LoginProvider));

        //        if (UserName != null)
        //        {
        //            claims.Add(new Claim(ClaimTypes.Name, UserName, null, LoginProvider));
        //        }

        //        return claims;
        //    }

        //    public static ExternalLoginData FromIdentity(ClaimsIdentity identity)
        //    {
        //        if (identity == null)
        //        {
        //            return null;
        //        }

        //        Claim providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);

        //        if (providerKeyClaim == null || String.IsNullOrEmpty(providerKeyClaim.Issuer)
        //            || String.IsNullOrEmpty(providerKeyClaim.Value))
        //        {
        //            return null;
        //        }

        //        if (providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
        //        {
        //            return null;
        //        }

        //        return new ExternalLoginData
        //        {
        //            LoginProvider = providerKeyClaim.Issuer,
        //            ProviderKey = providerKeyClaim.Value,
        //            UserName = identity.FindFirstValue(ClaimTypes.Name)
        //        };
        //    }
        //}

        //private static class RandomOAuthStateGenerator
        //{
        //    private static RandomNumberGenerator _random = new RNGCryptoServiceProvider();

        //    public static string Generate(int strengthInBits)
        //    {
        //        const int bitsPerByte = 8;

        //        if (strengthInBits % bitsPerByte != 0)
        //        {
        //            throw new ArgumentException("strengthInBits must be evenly divisible by 8.", "strengthInBits");
        //        }

        //        int strengthInBytes = strengthInBits / bitsPerByte;

        //        byte[] data = new byte[strengthInBytes];
        //        _random.GetBytes(data);
        //        return HttpServerUtility.UrlTokenEncode(data);
        //    }
        //}

        //#endregion

        //[HttpPost]
        //public async Task<HttpResponseMessage> Post()
        //{
        //    string value = await Request.Content.ReadAsStringAsync();

        //    return new HttpResponseMessage(HttpStatusCode.OK);
        //}

        // POST api/Account/RegisterExternal
        [Route("SaveData")]
        [HttpPost]
        public async Task<string> SaveToDB(string id, [FromBody] string data)
        {
            var rowData = JObject.Parse(data);
            int result;
            DataTable dtResult = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlMDFFile"].ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UpdateData", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", id);
                cmd.Parameters.AddWithValue("Column1" , rowData["Column1"] == null ? null : rowData["Column1"].ToString());
                cmd.Parameters.AddWithValue("Column2" , rowData["Column2"] == null ? null : rowData["Column2"].ToString());
                cmd.Parameters.AddWithValue("Column3" , rowData["Column3"] == null ? null : rowData["Column3"].ToString());
                cmd.Parameters.AddWithValue("Column4" , rowData["Column4"] == null ? null : rowData["Column4"].ToString());
                result = cmd.ExecuteNonQuery();
            }
            return  result > 0 ? "saved" : "failed";
        }
        [HttpGet]
        public dynamic getExcelData()
        {
            DataTable dtResult = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlMDFFile"].ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand("select * from excelData order by Id desc", connection);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                connection.Open();
                adapter.Fill(dtResult);
            }
            return dtResult;
        }
        [HttpPost]
       
        public dynamic UploadSingleFile()
        {
            try
            {
                var hfc = System.Web.HttpContext.Current.Request.Files;
                System.Web.HttpPostedFile hpf = hfc[0];
                var filename = System.Web.Hosting.HostingEnvironment.MapPath(string.Format("~/App_Data/{0}", hpf.FileName));
                hpf.SaveAs(filename);
                //ConvertExcelToDataTable(filename);
                var table = ConvertExcelToDataTable(hpf.FileName);
                //var table1 = JsonConvert.SerializeObject(table);
                //SaveToJSfile(hpf.FileName, table1);
                //SaveToCSVfile(hpf.FileName, table);
                return new { status= "server"};
            }
            catch
            {
                return new { status = "Invalid request, input must be an excel sheet (.xlsx)" };
            }
        }

        private static void SaveToCSVfile(string fileName, DataTable dtData)
        {
            var sPath = System.Web.Hosting.HostingEnvironment.MapPath(string.Format("~/Scripts/Data/{0}.csv", Path.GetFileNameWithoutExtension(fileName)));
            var valueLines = dtData.AsEnumerable()
                   .Select(row => string.Join(",", row.ItemArray));            
            File.WriteAllLines(sPath, valueLines);
        }

        private static void SaveToJSfile(string fileName, string value)
        {
            //JObject json = JObject.Parse(value);
            var sPath = System.Web.Hosting.HostingEnvironment.MapPath(string.Format("~/Scripts/Data/{0}.js", fileName));
            using (StreamWriter writetext = File.AppendText(sPath))
            {               
                writetext.WriteLine(value);
            }
        }
        private static DataTable ConvertExcelToDataTable(string fileName)
        {
            DataTable dtResult = null;
            int totalSheet = 0; //No of sheets on excel file 
            var sPath = System.Web.Hosting.HostingEnvironment.MapPath(string.Format("~/App_Data/{0}", fileName));
            using (OleDbConnection objConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sPath + ";Extended Properties='Excel 12.0;HDR=NO;IMEX=1;';"))
            {
                objConn.Open();
                OleDbCommand cmd = new OleDbCommand();
                OleDbDataAdapter oleda = new OleDbDataAdapter();
                DataSet ds = new DataSet();
                DataTable dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string sheetName = string.Empty;
                if (dt != null)
                {
                    // this is to make sure the correct sheet name is selected.
                    var tempDataTable = (from dataRow in dt.AsEnumerable()
                                         where !dataRow["TABLE_NAME"].ToString().Contains("FilterDatabase")
                                         select dataRow).CopyToDataTable();
                    dt = tempDataTable;
                    totalSheet = dt.Rows.Count;
                    sheetName = dt.Rows[0]["TABLE_NAME"].ToString();
                }
                cmd.Connection = objConn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
                oleda = new OleDbDataAdapter(cmd);
                oleda.Fill(ds, "excelData");             
                dtResult = ds.Tables["excelData"];
                if (dtResult.Columns.Count < 4)
                {
                    // making sure that the EXCEL sheet has 4 coulmns always.
                    for (int i = dtResult.Columns.Count; i < 4; i++)
                    {
                        DataColumn column = new DataColumn("F" + (i + 1));
                        column.DataType = System.Type.GetType("System.String");
                        column.DefaultValue = string.Empty;
                        dtResult.Columns.Add(column);
                    }                                       
                }
                objConn.Close();                
            }
            //using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlMDFFile"].ConnectionString))
            //{
            //    SqlDataAdapter adapter = new SqlDataAdapter();
            //    adapter.SelectCommand = new SqlCommand("select * from excelData", connection);
            //    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            //    connection.Open();                               
            //    adapter.Update(dtResult);
            //}
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlMDFFile"].ConnectionString))
            {
                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                {
                    //Set the database table name
                    sqlBulkCopy.DestinationTableName = "dbo.excelData";
                    sqlBulkCopy.ColumnMappings.Add("F1", "Column1");
                    sqlBulkCopy.ColumnMappings.Add("F2", "Column2");
                    sqlBulkCopy.ColumnMappings.Add("F3", "Column3");
                    sqlBulkCopy.ColumnMappings.Add("F4", "Column4");
                    con.Open();
                    sqlBulkCopy.WriteToServer(dtResult);
                    con.Close();
                }
            }
            return dtResult;
        }
    }
}
