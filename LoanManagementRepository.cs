using Camp6_Final_Angular.Models;
using Microsoft.EntityFrameworkCore;

namespace Camp6_Final_Angular.Repository
{
    public class LoanManagementRepository : ILoanManagementRepository
    {
        private readonly LoanManagementContext _context;

        public LoanManagementRepository(LoanManagementContext context)
        {
            _context = context; 
        }
        // Role methods
        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            try
            {
                return await _context.Roles.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                // throw new CustomException("An error occurred while retrieving roles.", ex);
                throw; // Rethrow the exception if you do not want to handle it
            }
        }

        public async Task<Role> GetRoleByIdAsync(int id) => await _context.Roles.FindAsync(id);
        public async Task AddRoleAsync(Role role) { await _context.Roles.AddAsync(role); await _context.SaveChangesAsync(); }
        public async Task UpdateRoleAsync(Role role) { _context.Roles.Update(role); await _context.SaveChangesAsync(); }
        public async Task DeleteRoleAsync(int id)
        {
            var role = await GetRoleByIdAsync(id);
            if (role != null)
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
            }
        }

        // Staff methods
        public async Task<IEnumerable<Staff>> GetAllStaffAsync() => await _context.Staff.ToListAsync();
        public async Task<Staff> GetStaffByIdAsync(int id) => await _context.Staff.FindAsync(id);
        public async Task AddStaffAsync(Staff staff) { await _context.Staff.AddAsync(staff); await _context.SaveChangesAsync(); }
        public async Task UpdateStaffAsync(Staff staff) { _context.Staff.Update(staff); await _context.SaveChangesAsync(); }
        public async Task DeleteStaffAsync(int id)
        {
            var staff = await GetStaffByIdAsync(id);
            if (staff != null)
            {
                _context.Staff.Remove(staff);
                await _context.SaveChangesAsync();
            }
        }

        // Customer methods
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync() => await _context.Customers.ToListAsync();
        public async Task<Customer> GetCustomerByIdAsync(int id) => await _context.Customers.FindAsync(id);
        public async Task AddCustomerAsync(Customer customer) { await _context.Customers.AddAsync(customer); await _context.SaveChangesAsync(); }
        public async Task UpdateCustomerAsync(Customer customer) { _context.Customers.Update(customer); await _context.SaveChangesAsync(); }
        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await GetCustomerByIdAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

        // Loan methods
        public async Task<IEnumerable<Loan>> GetAllLoansAsync() => await _context.Loans.Include(l => l.Customer).ToListAsync();
        public async Task<Loan> GetLoanByIdAsync(int id)
        {
            try
            {
                return await _context.Loans
                    .Include(l => l.Customer)
                    .FirstOrDefaultAsync(l => l.LoanId == id);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                // throw new CustomException("An error occurred while retrieving the loan.", ex);
                throw; // Rethrow the exception if you do not want to handle it
            }
        }

        public async Task AddLoanAsync(Loan loan) { await _context.Loans.AddAsync(loan); await _context.SaveChangesAsync(); }
        public async Task UpdateLoanAsync(Loan loan) { _context.Loans.Update(loan); await _context.SaveChangesAsync(); }
        public async Task DeleteLoanAsync(int id)
        {
            var loan = await GetLoanByIdAsync(id);
            if (loan != null)
            {
                _context.Loans.Remove(loan);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Loan>> GetLoansByCustomerIdAsync(int customerId)
            => await _context.Loans.Where(l => l.CustomerId == customerId).ToListAsync();

        // Background Verification methods
        public async Task<IEnumerable<BackgroundVerification>> GetAllBackgroundVerificationsAsync() => await _context.BackgroundVerifications.ToListAsync();
        public async Task<BackgroundVerification> GetBackgroundVerificationByIdAsync(int id) => await _context.BackgroundVerifications.FindAsync(id);
        public async Task AddBackgroundVerificationAsync(BackgroundVerification verification) { await _context.BackgroundVerifications.AddAsync(verification); await _context.SaveChangesAsync(); }
        public async Task UpdateBackgroundVerificationAsync(BackgroundVerification verification) { _context.BackgroundVerifications.Update(verification); await _context.SaveChangesAsync(); }
        public async Task DeleteBackgroundVerificationAsync(int id)
        {
            var verification = await GetBackgroundVerificationByIdAsync(id);
            if (verification != null)
            {
                _context.BackgroundVerifications.Remove(verification);
                await _context.SaveChangesAsync();
            }
        }

        // Help Section methods
        public async Task<IEnumerable<HelpSection>> GetAllHelpSectionsAsync() => await _context.HelpSections.ToListAsync();
        public async Task<HelpSection> GetHelpSectionByIdAsync(int id) => await _context.HelpSections.FindAsync(id);
        public async Task AddHelpSectionAsync(HelpSection helpSection) { await _context.HelpSections.AddAsync(helpSection); await _context.SaveChangesAsync(); }
        public async Task UpdateHelpSectionAsync(HelpSection helpSection) { _context.HelpSections.Update(helpSection); await _context.SaveChangesAsync(); }
        public async Task DeleteHelpSectionAsync(int id)
        {
            var helpSection = await GetHelpSectionByIdAsync(id);
            if (helpSection != null)
            {
                _context.HelpSections.Remove(helpSection);
                await _context.SaveChangesAsync();
            }
        }

        // Feedback methods
        public async Task<IEnumerable<Feedback>> GetAllFeedbacksAsync()
        {
            try
            {
                return await _context.Feedbacks.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                // throw new CustomException("An error occurred while retrieving feedbacks.", ex);
                throw; // Rethrow the exception if you do not want to handle it
            }
        }

        public async Task<Feedback> GetFeedbackByIdAsync(int id) => await _context.Feedbacks.FindAsync(id);
        public async Task AddFeedbackAsync(Feedback feedback) { await _context.Feedbacks.AddAsync(feedback); await _context.SaveChangesAsync(); }
        public async Task UpdateFeedbackAsync(Feedback feedback) { _context.Feedbacks.Update(feedback); await _context.SaveChangesAsync(); }
        public async Task DeleteFeedbackAsync(int id)
        {
            var feedback = await GetFeedbackByIdAsync(id);
            if (feedback != null)
            {
                _context.Feedbacks.Remove(feedback);
                await _context.SaveChangesAsync();
            }
        }
    }
}
