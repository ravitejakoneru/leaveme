using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaveMe.Data.Security
{
    
        public abstract class BaseViewPage : WebViewPage
        {
            public virtual new ApplicationPrincipal User
            {
                get { return base.User as ApplicationPrincipal; }
            }
        }
        public abstract class BaseViewPage<TModel> : WebViewPage<TModel>
        {
            public virtual new ApplicationPrincipal User
            {
                get { return base.User as ApplicationPrincipal; }
            }
        }
    
}