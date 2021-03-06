namespace NavigationSample.Modules.Edit
{
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

    using NavigationSample.Models.Entity;
    using NavigationSample.Services;

    using Smart.Collections.Generic;
    using Smart.Forms.Input;
    using Smart.Navigation;

    public class EditListViewModel : AppViewModelBase
    {
        private readonly DataService dataService;

        public ObservableCollection<DataEntity> Items { get; } = new();

        public AsyncCommand<DataEntity> SelectCommand { get; }

        public AsyncCommand BackCommand { get; }

        public AsyncCommand NewCommand { get; }

        public EditListViewModel(
            ApplicationState applicationState,
            DataService dataService)
            : base(applicationState)
        {
            this.dataService = dataService;

            BackCommand = MakeAsyncCommand(OnNotifyBackAsync);
            SelectCommand = MakeAsyncCommand<DataEntity>(x =>
                Navigator.ForwardAsync(ViewId.EditDetailUpdate, new NavigationParameter().SetValue(x)));
            NewCommand = MakeAsyncCommand(() => Navigator.ForwardAsync(ViewId.EditDetailNew));
        }

        public override void OnNavigatedTo(INavigationContext context)
        {
            if (!context.Attribute.IsRestore())
            {
                Items.AddRange(dataService.QuerySampleList());
            }
        }

        protected override Task OnNotifyBackAsync()
        {
            return Navigator.ForwardAsync(ViewId.Menu);
        }
    }
}
