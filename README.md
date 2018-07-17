# Northwind.Core

Each northwind entity has a collection view model.
 *So far: CustomersViewModel, OrdersViewModel , ProductsViewModel

Collection view models have two properties:
- RefreshCommand (Refreshes the collection)
- Items (Elements of the collection)

Items are view models which expose the following properties:
- DataObject (Represents the entity: Customer, Product, Order)
- DeleteCommand
- RefreshCommand
- SaveCommand

e.g:
this.DataContext = new CustomersCollectionViewModel();

For a DataGrid: (Customers and its Orders)
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
 
