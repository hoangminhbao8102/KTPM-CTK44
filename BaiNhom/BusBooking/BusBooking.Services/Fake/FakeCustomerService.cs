using BusBooking.Core.Entities;
using BusBooking.Services.Interface;

namespace BusBooking.Services.Fake
{
    public class FakeCustomerService : ICustomerService
    {
        private readonly List<Customer> _customers = new List<Customer>();

        /// <summary>
        /// Tạo FakeCustomerService với dữ liệu mẫu (nếu cần)
        /// </summary>
        /// <param name="initialCustomers">Danh sách khách hàng mẫu</param>
        public FakeCustomerService(IEnumerable<Customer> initialCustomers = null)
        {
            if (initialCustomers != null)
            {
                _customers.AddRange(initialCustomers);
            }
        }

        public Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult<IEnumerable<Customer>>(_customers);
        }

        public Task<Customer> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(customer);
        }

        public Task<Customer> AuthenticateAsync(string email, string password, CancellationToken cancellationToken = default)
        {
            var customer = _customers.FirstOrDefault(c =>
                string.Equals(c.Email, email, StringComparison.OrdinalIgnoreCase) &&
                c.Password == password);

            return Task.FromResult(customer);
        }

        public Task AddAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            // Giả lập thêm với Id tự động tăng (nếu chưa có Id)
            if (customer.Id == 0)
            {
                customer.Id = _customers.Count > 0 ? _customers.Max(c => c.Id) + 1 : 1;
            }

            _customers.Add(customer);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            var existing = _customers.FirstOrDefault(c => c.Id == customer.Id);
            if (existing != null)
            {
                existing.Email = customer.Email;
                existing.Password = customer.Password;
                existing.FullName = customer.FullName;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                _customers.Remove(customer);
            }
            return Task.CompletedTask;
        }
    }
}
