 ## Purpose
 
 Its purpose is mostly for creating quick sample tests for prototyping and testing WPF, Xamarin and UWP funtionality.

You may be working on a big proyect and something isn't working as expected, you'd rather spin up a new proyect to test seperately but don't want to go over the process of creating view model collections, bindable bases etc.

The idea is to copy/paste from here and get your sample proyect up as quiclkly as possible.

e.g:
 - Testing some specific styling on an item control, item template.
 - Changing the control template of a items control, tree view etc
 - Syling the item container
 - Trying out a custom ItemTemplateSelector
 - Need to test hierarchical tempaltes in a tree 
 
 In all these cases you can add the reference and copy and past from here etc
 
 ## Description
 
 Each Northwind entity has a collection view model.  
 
 *So far: CustomersCollectionViewModel, OrdersCollectionViewModel , ProductsCollectionViewModel, EmployeesCollectionViewModel*

Collection view models have two properties:
- RefreshCommand (Refreshes the collection)
- Items (Elements of the collection as an Observablecollection)

Items are view models which expose the following properties:
- DataObject (The Northwind entity: Customer, Product, Order)
- Children (A child collection of view models, used so far with the EmployeeViewModel, to be used with hierarchical templates)
- DeleteCommand
- RefreshCommand
- SaveCommand

## For WPF

#### DataGrid
```
e.g: (Customers and their Orders)

this.DataContext = new CustomersCollectionViewModel();

<DataGrid Grid.Row="0" Name="Customers" ItemsSource="{Binding Items, Mode=OneWay}" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding DataObject.CustomerID}"></DataGridTextColumn>
                <DataGridTextColumn Binding="{Binding DataObject.CompanyName}"></DataGridTextColumn>
                 <DataGridTextColumn Binding="{Binding DataObject.ContactName}"></DataGridTextColumn>
                <DataGridTextColumn Binding="{Binding DataObject.ContactTitle}"></DataGridTextColumn>
                <DataGridTextColumn Binding="{Binding DataObject.Address}"></DataGridTextColumn>
                <DataGridTextColumn Binding="{Binding DataObject.City}"></DataGridTextColumn>
                <DataGridTextColumn Binding="{Binding DataObject.Country}"></DataGridTextColumn>
            </DataGrid.Columns>
        </DataGrid>
       
  <Border Grid.Row="1" Height="5" Background="Green"></Border>

        <DataGrid Grid.Row="2" Name="Orders" ItemsSource="{Binding SelectedItem.Orders.Items, ElementName=Customers, Mode=OneWay}" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding DataObject.OrderID}"></DataGridTextColumn>
                <DataGridTextColumn Binding="{Binding DataObject.CustomerID}"></DataGridTextColumn>
                <DataGridTextColumn Binding="{Binding DataObject.OrderDate}"></DataGridTextColumn>
                <DataGridTextColumn Binding="{Binding DataObject.ShippedDate}"></DataGridTextColumn>
                <DataGridTextColumn Binding="{Binding DataObject.ShipAddress}"></DataGridTextColumn>
                <DataGridTextColumn Binding="{Binding DataObject.ShipCity}"></DataGridTextColumn>
                <DataGridTextColumn Binding="{Binding DataObject.ShipRegion}"></DataGridTextColumn>
            </DataGrid.Columns>
        </DataGrid>
 ```
 
 #### Or in a ListView:
 
 ```
 <ListView ItemsSource="{Binding Items, Mode=OneWay}">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <Grid.RowDefinitions>
                            <RowDefinition></RowDefinition>
                            <RowDefinition></RowDefinition>
                        </Grid.RowDefinitions>

                        <Label Grid.Row="0" Content="{Binding DataObject.CustomerID}"></Label>
                        <Label Grid.Row="1" Content="{Binding DataObject.Country}"></Label>
                    </Grid>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
 ```
 
  #### Or in a TreeView: (With EmployeesCollectionViewModel)
 
 ```
<TreeView Grid.Row="1" ItemsSource="{Binding Items, Mode=OneWay}">
            <TreeView.ItemTemplate>
                <HierarchicalDataTemplate ItemsSource="{Binding Children}">
                    <Grid>
                        <Grid.RowDefinitions>
                            <RowDefinition></RowDefinition>
                            <RowDefinition></RowDefinition>
                        </Grid.RowDefinitions>

                        <Label Grid.Row="0" Content="{Binding DataObject.EmployeeID}"></Label>
                        <Label Grid.Row="1" Content="{Binding DataObject.LastName}"></Label>
                    </Grid>
                </HierarchicalDataTemplate>
            </TreeView.ItemTemplate>
        </TreeView>
 ```
 
 ## For Xamarin.Forms with PRISM
 
 - We need to specify view models for each view, we can't use the default as they belong to a different assembly in this case Northwind.Core.
 - Collection view models have a dependency on service abstractions, e.g: HttpCustomersService, HttpProductsService, these will be responsible for invoking ODATA northwind services and mapping to a northwind data object.
 
 ```
   protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NorthwindMasterDetail, NorthwindMasterDetailViewModel>("Index");
            containerRegistry.RegisterForNavigation<NavigationPage>("Navigation");

            containerRegistry.RegisterInstance<ICustomersService>(new HttpCustomersService());
            containerRegistry.RegisterInstance<IProductsService>(new HttpProductsService());

            containerRegistry.RegisterForNavigation<Customers, CustomersViewModel>("Customers");
            containerRegistry.RegisterForNavigation<Products,ProductsViewModel>("Products");
        }
```

An example using a MasterDetail page using PRISM's navigation service

```
 protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("Index/Navigation/Customers");
        }
```

View sample, Customers.xaml

```
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:prism="clr-namespace:Prism.Mvvm;assembly=Prism.Forms"
             prism:ViewModelLocator.AutowireViewModel="True"
             x:Class="Northwind.Forms.Views.Customers">
    <ListView ItemsSource="{Binding Items, Mode=OneWay}">
        <ListView.ItemTemplate>
            <DataTemplate>
                <ViewCell>
                    <Grid>
                        <Grid.RowDefinitions>
                            <RowDefinition></RowDefinition>
                            <RowDefinition></RowDefinition>
                        </Grid.RowDefinitions>

                        <Label Grid.Row="0" Text="{Binding DataObject.CustomerID}"></Label>
                        <Label Grid.Row="1" Text="{Binding DataObject.Country}"></Label>
                    </Grid>
                </ViewCell>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
</ContentPage>
```

## Extending a view model

```
public class MyCustomersCollectionViewModel : CustomersCollectionViewModel
    {
        protected override NorthwindItemViewModelBase<Customer> GetNorthwindItemViewModel(Customer item, INorthwindServiceBase<Customer> service)
        {
            return new MyCustomerViewModel(item);
        }
    }
    
   public class MyCustomerViewModel : Northwind.Core.ViewModels.Customers.CustomerItemViewModel
    {
        public MyCustomerViewModel(Customer customer) : base(customer)
        {
            this.Property1 = "Name";
        }

        public MyCustomerViewModel(Customer customer, IOrdersService ordersService, ICustomersService service) : base(customer, ordersService, service)
        {
            this.Property2 = "Surname";
        }

        public string Property1 { get; set; }

        public string Property2 { get; set; }
    }
```

We then set the data context:

```
this.DataContext = new MyCustomersCollectionViewModel();
```
