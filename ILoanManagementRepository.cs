using Camp6_Final_Angular.Models;

namespace Camp6_Final_Angular.Repository
{
    public interface ILoanManagementRepository
    {
        // Role methods
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<Role> GetRoleByIdAsync(int id);
        Task AddRoleAsync(Role role);
        Task UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(int id);

        // Staff methods
        Task<IEnumerable<Staff>> GetAllStaffAsync();
        Task<Staff> GetStaffByIdAsync(int id);
        Task AddStaffAsync(Staff staff);
        Task UpdateStaffAsync(Staff staff);
        Task DeleteStaffAsync(int id);

        // Customer methods
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task AddCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int id);

        // Loan methods
        Task<IEnumerable<Loan>> GetAllLoansAsync();
        Task<Loan> GetLoanByIdAsync(int id);
        Task AddLoanAsync(Loan loan);
        Task UpdateLoanAsync(Loan loan);
        Task DeleteLoanAsync(int id);
        Task<IEnumerable<Loan>> GetLoansByCustomerIdAsync(int customerId);

        // Background Verification methods
        Task<IEnumerable<BackgroundVerification>> GetAllBackgroundVerificationsAsync();
        Task<BackgroundVerification> GetBackgroundVerificationByIdAsync(int id);
        Task AddBackgroundVerificationAsync(BackgroundVerification verification);
        Task UpdateBackgroundVerificationAsync(BackgroundVerification verification);
        Task DeleteBackgroundVerificationAsync(int id);

        // Help Section methods
        Task<IEnumerable<HelpSection>> GetAllHelpSectionsAsync();
        Task<HelpSection> GetHelpSectionByIdAsync(int id);
        Task AddHelpSectionAsync(HelpSection helpSection);
        Task UpdateHelpSectionAsync(HelpSection helpSection);
        Task DeleteHelpSectionAsync(int id);

        // Feedback methods
        Task<IEnumerable<Feedback>> GetAllFeedbacksAsync();
        Task<Feedback> GetFeedbackByIdAsync(int id);
        Task AddFeedbackAsync(Feedback feedback);
        Task UpdateFeedbackAsync(Feedback feedback);
        Task DeleteFeedbackAsync(int id);

    }
}
