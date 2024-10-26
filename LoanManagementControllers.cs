using Camp6_Final_Angular.Models;
using Camp6_Final_Angular.Repository;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Camp6_Final_Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanManagementControllers : ControllerBase
    {
        private readonly ILoanManagementRepository _repository;

        public LoanManagementControllers(ILoanManagementRepository repository)
        {
            _repository = repository;   
        }
        [HttpGet("roles")]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            var roles = await _repository.GetAllRolesAsync();
            return Ok(roles);
        }

        [HttpGet("roles/{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            var role = await _repository.GetRoleByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpPost("roles")]
        public async Task<ActionResult> AddRole(Role role)
        {
            await _repository.AddRoleAsync(role);
            return CreatedAtAction(nameof(GetRole), new { id = role.RoleId }, role);
        }

        [HttpPut("roles/{id}")]
        public async Task<ActionResult> UpdateRole(int id, Role role)
        {
            if (id != role.RoleId)
            {
                return BadRequest();
            }
            await _repository.UpdateRoleAsync(role);
            return NoContent();
        }

        [HttpDelete("roles/{id}")]
        public async Task<ActionResult> DeleteRole(int id)
        {
            await _repository.DeleteRoleAsync(id);
            return NoContent();
        }

        [HttpGet("staff")]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaff()
        {
            var staff = await _repository.GetAllStaffAsync();
            return Ok(staff);
        }

        [HttpGet("staff/{id}")]
        public async Task<ActionResult<Staff>> GetStaff(int id)
        {
            var staffMember = await _repository.GetStaffByIdAsync(id);
            if (staffMember == null)
            {
                return NotFound();
            }
            return Ok(staffMember);
        }

        [HttpPost("staff")]
        public async Task<ActionResult> AddStaff(Staff staff)
        {
            await _repository.AddStaffAsync(staff);
            return CreatedAtAction(nameof(GetStaff), new { id = staff.StaffId }, staff);
        }

        [HttpPut("staff/{id}")]
        public async Task<ActionResult> UpdateStaff(int id, Staff staff)
        {
            if (id != staff.StaffId)
            {
                return BadRequest();
            }
            await _repository.UpdateStaffAsync(staff);
            return NoContent();
        }

        [HttpDelete("staff/{id}")]
        public async Task<ActionResult> DeleteStaff(int id)
        {
            await _repository.DeleteStaffAsync(id);
            return NoContent();
        }

        [HttpGet("customers")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _repository.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("customers/{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _repository.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost("customers")]
        public async Task<ActionResult> AddCustomer(Customer customer)
        {
            await _repository.AddCustomerAsync(customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustomerId }, customer);
        }

        [HttpPut("customers/{id}")]
        public async Task<ActionResult> UpdateCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }
            await _repository.UpdateCustomerAsync(customer);
            return NoContent();
        }

        [HttpDelete("customers/{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            await _repository.DeleteCustomerAsync(id);
            return NoContent();
        }

        [HttpGet("loans")]
        public async Task<ActionResult<IEnumerable<Loan>>> GetLoans()
        {
            var loans = await _repository.GetAllLoansAsync();
            return Ok(loans);
        }

        [HttpGet("loans/{id}")]
        public async Task<ActionResult<Loan>> GetLoan(int id)
        {
            var loan = await _repository.GetLoanByIdAsync(id);
            if (loan == null)
            {
                return NotFound();
            }
            return Ok(loan);
        }

        [HttpPost("loans")]
        public async Task<ActionResult> AddLoan(Loan loan)
        {
            await _repository.AddLoanAsync(loan);
            return CreatedAtAction(nameof(GetLoan), new { id = loan.LoanId }, loan);
        }

        [HttpPut("loans/{id}")]
        public async Task<ActionResult> UpdateLoan(int id, Loan loan)
        {
            if (id != loan.LoanId)
            {
                return BadRequest();
            }
            await _repository.UpdateLoanAsync(loan);
            return NoContent();
        }

        [HttpDelete("loans/{id}")]
        public async Task<ActionResult> DeleteLoan(int id)
        {
            await _repository.DeleteLoanAsync(id);
            return NoContent();
        }

        [HttpGet("loans/customer/{customerId}")]
        public async Task<ActionResult<IEnumerable<Loan>>> GetLoansByCustomerId(int customerId)
        {
            var loans = await _repository.GetLoansByCustomerIdAsync(customerId);
            return Ok(loans);
        }

        [HttpGet("background-verifications")]
        public async Task<ActionResult<IEnumerable<BackgroundVerification>>> GetBackgroundVerifications()
        {
            var verifications = await _repository.GetAllBackgroundVerificationsAsync();
            return Ok(verifications);
        }

        [HttpGet("background-verifications/{id}")]
        public async Task<ActionResult<BackgroundVerification>> GetBackgroundVerification(int id)
        {
            var verification = await _repository.GetBackgroundVerificationByIdAsync(id);
            if (verification == null)
            {
                return NotFound();
            }
            return Ok(verification);
        }

        [HttpPost("background-verifications")]
        public async Task<ActionResult> AddBackgroundVerification(BackgroundVerification verification)
        {
            await _repository.AddBackgroundVerificationAsync(verification);
            return CreatedAtAction(nameof(GetBackgroundVerification), new { id = verification.VerificationId }, verification);
        }

        [HttpPut("background-verifications/{id}")]
        public async Task<ActionResult> UpdateBackgroundVerification(int id, BackgroundVerification verification)
        {
            if (id != verification.VerificationId)
            {
                return BadRequest();
            }
            await _repository.UpdateBackgroundVerificationAsync(verification);
            return NoContent();
        }

        [HttpDelete("background-verifications/{id}")]
        public async Task<ActionResult> DeleteBackgroundVerification(int id)
        {
            await _repository.DeleteBackgroundVerificationAsync(id);
            return NoContent();
        }

        [HttpGet("help-sections")]
        public async Task<ActionResult<IEnumerable<HelpSection>>> GetHelpSections()
        {
            var helpSections = await _repository.GetAllHelpSectionsAsync();
            return Ok(helpSections);
        }

        [HttpGet("help-sections/{id}")]
        public async Task<ActionResult<HelpSection>> GetHelpSection(int id)
        {
            var helpSection = await _repository.GetHelpSectionByIdAsync(id);
            if (helpSection == null)
            {
                return NotFound();
            }
            return Ok(helpSection);
        }

        [HttpPost("help-sections")]
        public async Task<ActionResult> AddHelpSection(HelpSection helpSection)
        {
            await _repository.AddHelpSectionAsync(helpSection);
            return CreatedAtAction(nameof(GetHelpSection), new { id = helpSection.HelpId }, helpSection);
        }

        [HttpPut("help-sections/{id}")]
        public async Task<ActionResult> UpdateHelpSection(int id, HelpSection helpSection)
        {
            if (id != helpSection.HelpId)
            {
                return BadRequest();
            }
            await _repository.UpdateHelpSectionAsync(helpSection);
            return NoContent();
        }

        [HttpDelete("help-sections/{id}")]
        public async Task<ActionResult> DeleteHelpSection(int id)
        {
            await _repository.DeleteHelpSectionAsync(id);
            return NoContent();
        }

        [HttpGet("feedbacks")]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetFeedbacks()
        {
            var feedbacks = await _repository.GetAllFeedbacksAsync();
            return Ok(feedbacks);
        }

        [HttpGet("feedbacks/{id}")]
        public async Task<ActionResult<Feedback>> GetFeedback(int id)
        {
            var feedback = await _repository.GetFeedbackByIdAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }
            return Ok(feedback);
        }

        [HttpPost("feedbacks")]
        public async Task<ActionResult> AddFeedback(Feedback feedback)
        {
            await _repository.AddFeedbackAsync(feedback);
            return CreatedAtAction(nameof(GetFeedback), new { id = feedback.FeedbackId }, feedback);
        }

        [HttpPut("feedbacks/{id}")]
        public async Task<ActionResult> UpdateFeedback(int id, Feedback feedback)
        {
            if (id != feedback.FeedbackId)
            {
                return BadRequest();
            }
            await _repository.UpdateFeedbackAsync(feedback);
            return NoContent();
        }
    }
}
