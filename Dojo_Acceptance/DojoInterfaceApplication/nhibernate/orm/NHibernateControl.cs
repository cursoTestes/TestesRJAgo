using System;
using System.Web;
using NHibernate;
using NHibernate.Cfg;
namespace NHibernateHelpers
{
    public sealed class NHibernateControl
    {
        private const string CurrentSessionKey = "nhibernate.current_session";
        private static readonly ISessionFactory sessionFactory;
        static NHibernateControl()
        {
            NHibernate.Cfg.Configuration cfg = new NHibernate.Cfg.Configuration();
            cfg.Configure();
            string basePath = System.Web.HttpContext.Current.Server.MapPath(@"App_Code/");
            cfg.AddXmlFile(basePath + "User.hbm.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }
        public static ISession GetCurrentSession()
        {
            HttpContext context = HttpContext.Current;
            ISession currentSession = context.Items[CurrentSessionKey] as ISession; if (currentSession == null)
            {
                currentSession = sessionFactory.OpenSession();
                context.Items[CurrentSessionKey] = currentSession;
            } return currentSession;
        }
        public static void CloseSession()
        {
            HttpContext context = HttpContext.Current;
            ISession currentSession = context.Items[CurrentSessionKey] as ISession; if (currentSession == null)
            {
                // No current session
                return;
            } currentSession.Close();
            context.Items.Remove(CurrentSessionKey);
        }
        public static void CloseSessionFactory()
        {
            if (sessionFactory != null)
            {
                sessionFactory.Close();
            }
        }
    }
}