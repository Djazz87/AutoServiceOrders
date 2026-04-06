«Grid RowDefinitions="* Auto">
< ListBox Grid.Row="0"
ItemsSource="{Binding (WorksWindowViewModel). Path= Works }">
‹ListBox. ItemTemplate>
< DataTemplate>
«CheckBox IsChecked="{Binding
(Works). Path= Selected}">
‹CheckBox. Content>
‹MultiBinding StringFormat="(J-{0} {1}">
«Binding Path=" (Works), Work_name" /> <Binding Path=" (Works), Price"/>
</MultiBinding>
</ CheckBox.Content>
</CheckBox>
</DataTemplate>
</ListBox.ItemTemplate>
</ListBox»
‹Button Grid.Row="1" Content="вывести чек"
