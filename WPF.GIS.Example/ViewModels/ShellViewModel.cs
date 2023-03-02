using Caliburn.Micro;
using Ironwall.Framework.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WPF.GIS.Example.ViewModels.Maps;

namespace WPF.GIS.Example.ViewModels
{
    public class ShellViewModel : BaseShellViewModel
    {
        #region - Ctors -
        /// <summary>
        /// Initializes a new instance of the <see cref="ShellViewModel"/> class.
        /// </summary>
        public ShellViewModel(
            MapViewModel mapViewModel
            )
    {
            MapViewModel = mapViewModel;
    }

    #endregion
    #region - Implementation of Interface -
    #endregion
    #region - Overrides -
    protected override async Task OnActivateAsync(CancellationToken cancellationToken)
    {
            await MapViewModel.ActivateAsync();
    }

    protected override async Task OnDeactivateAsync(bool close, CancellationToken cancellationToken)
    {
            await MapViewModel.DeactivateAsync(true);
    }
    #endregion
    #region - Binding Methods -
    public async void OnClosing(object sender, CancelEventArgs e)
    {
        e.Cancel = true;

        if (_isCallExit)
            return;

        _isCallExit = true;



        await Task.Delay(1000);
        App.Current.Shutdown();
    }
    #endregion
    #region - Processes -
    #endregion
    #region - IHanldes -
    #endregion
    #region - Properties -
    #endregion
    #region - Attributes -
    private bool _isCallExit;

        public MapViewModel MapViewModel { get; }
        #endregion
    }
}
