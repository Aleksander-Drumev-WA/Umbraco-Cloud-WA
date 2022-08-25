using Umbraco.Cms.Core.Notifications;
using UmbracoExercise.Core.Data;

namespace UmbracoExercise.Extensions
{
    public static class UmbracoBuilderExtension
    {
        public static IUmbracoBuilder AddMessages(this IUmbracoBuilder builder)
        {
            builder.AddNotificationHandler<UmbracoApplicationStartingNotification, RunMessagesMigration>();
            return builder;
        }
    }
}
