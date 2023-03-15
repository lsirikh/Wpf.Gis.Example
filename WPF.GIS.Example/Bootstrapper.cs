using Ironwall.Framework.Modules;
using Ironwall.Framework.Services;
using Ironwall.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF.GIS.Example.ViewModels;
using Autofac;
using WPF.GIS.Example.ViewModels.Maps;
using GMap.NET.WindowsPresentation;

namespace WPF.GIS.Example
{
    public class Bootstrapper
        : ParentBootstrapper<ShellViewModel>
    {
        #region - Ctors -
        public Bootstrapper()
        {
            Initialize();
        }
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -

        protected override async void OnStartup(object sender, StartupEventArgs e)
        {
            /////////////////////////// Ironwall.Libraries.WatchDog 실행 /////////////////////////////////
            //Process[] procs = Process.GetProcesses();
            


            base.OnStartup(sender, e);



            //await Start();
            await DisplayRootViewForAsync<ShellViewModel>();
        }

        protected override void OnExit(object sender, EventArgs e)
        {
            Stop();
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            try
            {
                base.ConfigureContainer(builder);
                builder.RegisterType<MapViewModel>().SingleInstance();

                var mapControl = new GMapControl();
                builder.RegisterInstance(mapControl).AsSelf().SingleInstance();

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Raised Exception in {nameof(ConfigureContainer)} : {ex.Message}");
            }
        }


        #endregion
        #region - Procedures - 
        #endregion
        #region - Properties - 
        #endregion
        #region - Attributes - 
        #endregion
    }
}
