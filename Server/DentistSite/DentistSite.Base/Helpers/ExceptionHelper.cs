using System;
using System.Data.Entity.Validation;
using NLog;

namespace DentistSite.Base.Helpers
{
    public static class ExceptionHelper
    {
        public static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Handles the error.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="catchException">if set to <c>true</c> [catch exception].</param>
        /// <param name="logError">if set to <c>true</c> [log error].</param>
        public static void HandleError(Action action, bool catchException = false, bool logError = true)
        {
            try
            {
                action();
            }

            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Logger.Error("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Logger.Error("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (Exception e)
            {

                if (logError)
                    Logger.Error(e);

                if (!catchException)
                   throw;
            }
        }

        /// <summary>
        /// Handles the error.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="refreshAction">The refresh action.</param>
        public static void HandleError(Action action, Action refreshAction)
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                Logger.Error(e);

                refreshAction();
            }
        }

        public static void HandleError(Action action, Action<Exception> refreshAction)
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                Logger.Error(e);

                refreshAction(e);

               throw;
            }
        }
    }
}
