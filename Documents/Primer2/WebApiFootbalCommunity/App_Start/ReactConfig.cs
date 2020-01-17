using React;
using JavaScriptEngineSwitcher.Core;
using JavaScriptEngineSwitcher.V8;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebApiFootbalCommunity.ReactConfig), "Configure")]

namespace WebApiFootbalCommunity
{
	public static class ReactConfig
	{
		public static void Configure()
		{
            ReactSiteConfiguration.Configuration.AddScript("~/Scripts/React/Test.js");
            ReactSiteConfiguration.Configuration.AddScript("~/Scripts/React/Login.jsx");
            ReactSiteConfiguration.Configuration.AddScript("~/Scripts/React/Fixture.jsx");

            JsEngineSwitcher.Current.DefaultEngineName = V8JsEngine.EngineName;
            JsEngineSwitcher.Current.EngineFactories.AddV8();
		}
	}
}