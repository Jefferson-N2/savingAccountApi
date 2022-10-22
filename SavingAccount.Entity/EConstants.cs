using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingAccount.Entity
{
    public class EConstants
    {
        #region DATABASE_CONECTION
        private const string DATA_SOURCE = "";
        private const string PORT = "";
        private const string PASSWORD = ".";
        private const String USER = "";
        private const string DATABASE = "";
        public const string CONNECTION_BD = "Data Source = " + DATA_SOURCE + "," + PORT + "; Initial Catalog = "+ DATABASE 
            + "; Persist Security info= True ;User ID=" + USER + ";Password=" + PASSWORD;

        #endregion DATABASE_CONECTION

        #region PAHT_CONTROLLERS
        public const string RESOURCE_ACCOUNT = "SearchAccounts";
        public const string RESOURCE_CLIENT = "SearchClients";
        public const string RESOURCE_BALANCE = "SearchBalance";
        public const string RESOURCE_ACCOUNT_ID = "SearchAccountID";
        public const string RESOURCE_CLIENT_ID = "SearchClientID";
        public const string RESOURCE_BALANCE_ID = "SearchBalanceID";
        public const string RESOURCE_CREATE_ACCOUNT = "CreateAccount";
        public const string RESOURCE_CREATE_CLIENT = "CreateClient";
        public const string RESOURCE_CREATE_BALANCE = "CreateBalance";


        #endregion PAHT_CONTROLLERS




        #region ACCOUNT_BASE

        public const long ACOUNT_BASE = 10000000000;
        public const string ACOOUNT_NAME = "AHORRO";

        #endregion  ACCOUNT_BASE


        #region CONSTANTS_VALUES
        public const int INT_YEAR = 12;
        public const int INT_DECIMAL = 5;
        public const int ZERO = 0;
        public const string REGEX_STRING = @"^[a-zA-ZáéíóúüñÁÉÍÓÚÜÑ_0-9\r\s\n\{\}\/\-\?\:\(\)\.\,\'\+\&\\]*$";
        public const string REGEX_INT = @"^[0-9]*$";
        public const string OK = "OK";
        public const string COD_OK = "0";
        #endregion CONSTANTS_VALUES

        #region Validaciones

        public const string Max_MESSAGE_CI = "La identificacion debe poseer 10 digitos";
        public const string EMPTY_MESSAGE = "Valor no puede ser vacio";
        public const string NULL_MESSAGE = "Valor no puede ser vacio";
        public const string STRG_MESSAGE = "Solo se permiten letras";
        public const string INT_MESSAGE = "Solo se permite numeros";
        public const string AMOUNT_MESSAGE = "El valor minimo debe de ser:  $100";

        #endregion Validaciones
    }
}
