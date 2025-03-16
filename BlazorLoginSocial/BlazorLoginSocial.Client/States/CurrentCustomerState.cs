using Blazored.LocalStorage;
using BlazorLoginSocial.Domain.Entities;

namespace BlazorLoginSocial.Client.States
{
    public class CurrentCustomerState
    {
        public Action? CustomerSelected { get; set; }

        private void OnCustomerSelected()
            => CustomerSelected?.Invoke();

        private const string CustomerKey = "Customer";

        public async Task SetCurrentCustomerAsync(Customer customer, ILocalStorageService localStorage)
        {
            await localStorage.SetItemAsync(CustomerKey, customer);
            OnCustomerSelected();
        }

        public static ValueTask<Customer?> GetCurrentCustomerAsync(ILocalStorageService localStorage)
            => localStorage.GetItemAsync<Customer>(CustomerKey);

        public static ValueTask<bool> ExistsCurrentCustomerAsync(ILocalStorageService localStorage)
            => localStorage.ContainKeyAsync(CustomerKey);



    }
}
