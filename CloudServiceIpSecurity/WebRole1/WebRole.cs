using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Hosting;
using Microsoft.Web.Administration;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace WebRole1
{
    public class WebRole : RoleEntryPoint
    {
        public override bool OnStart()
        {
            // For information on handling configuration changes
            // see the MSDN topic at https://go.microsoft.com/fwlink/?LinkId=166357.

            return base.OnStart();
        }

        void RoleEnvironment_Changing(object sender, RoleEnvironmentChangingEventArgs e)
        {
            var configurationChanges = e.Changes
                .OfType<RoleEnvironmentConfigurationSettingChange>()
                .ToList();


            if (!configurationChanges.Any()) return;

            if (configurationChanges.Any(c => c.ConfigurationSettingName == "StorageAccount"))
                e.Cancel = true;
        }


    }
}
