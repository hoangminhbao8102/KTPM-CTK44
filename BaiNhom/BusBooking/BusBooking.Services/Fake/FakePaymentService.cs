using BusBooking.Core.Entities;
using BusBooking.Services.Interface;

namespace BusBooking.Services.Fake
{
    public class FakePaymentService : IPaymentService
    {
        private readonly List<Payment> _payments = new List<Payment>();

        /// <summary>
        /// Khởi tạo fake với dữ liệu ban đầu (nếu có)
        /// </summary>
        public FakePaymentService(IEnumerable<Payment> initialPayments = null)
        {
            if (initialPayments != null)
            {
                _payments.AddRange(initialPayments);
            }
        }

        /// <summary>
        /// Giả lập lấy tất cả payment
        /// </summary>
        public Task<IEnumerable<Payment>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult<IEnumerable<Payment>>(_payments);
        }

        /// <summary>
        /// Giả lập lấy payment theo Id
        /// </summary>
        public Task<Payment> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var payment = _payments.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(payment);
        }

        /// <summary>
        /// Giả lập thêm payment (tự động tăng Id nếu chưa có)
        /// </summary>
        public Task AddAsync(Payment payment, CancellationToken cancellationToken = default)
        {
            if (payment.Id == 0)
            {
                payment.Id = _payments.Count > 0 ? _payments.Max(p => p.Id) + 1 : 1;
            }

            _payments.Add(payment);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Trả về danh sách payment đã được thêm để kiểm tra trong test
        /// </summary>
        public IEnumerable<Payment> AddedPayments => _payments;
    }
}
