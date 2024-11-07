using BusinessObject;
using DataAccess;

namespace Repositories.Impl
{
    public class TakeLeaveRepository : ITakeLeaveRepository
    {
        public int CalculateLeaveDays(DateTime startDate, DateTime endDate)

        => TakeLeaveDAO.CalculateLeaveDays(startDate, endDate);


        public int CalculateLeaveDaysByEmployeeIdEqualAndMonthEqualAndYearEqual(int employeeId, DateTime startDate, DateTime endDate)
        {
            return TakeLeaveDAO.CalculateLeaveDaysByEmployeeIdEqualAndMonthEqualAndYearEqual(employeeId, startDate, endDate);
        }

        public int CalculateLeaveDaysByEmployeeIdEqualAndYearEqual(int employeeId, int year)
        {
            return TakeLeaveDAO.CalculateLeaveDaysByEmployeeIdEqualAndYearEqual(employeeId, year);
        }

        public void DeleteTakeLeave(TakeLeave takeLeave)
        {
            TakeLeaveDAO.DeleteTakeLeave(takeLeave);
        }

        public bool ExistApprovedAttendanceByDateEqualAndEmployeeEqual(int employeeId, DateTime startDate, DateTime endDate)
        {
            return TakeLeaveDAO.ExistApprovedAttendanceByDateEqualAndEmployeeEqual(employeeId, startDate, endDate);
        }



        public IEnumerable<TakeLeave> GetAllTakeLeavesByDateBetween(DateTime startDate, DateTime endDate)
        {
            return TakeLeaveDAO.GetAllTakeLeaveByDayBetween(startDate, endDate);
        }

        public IEnumerable<TakeLeave> GetAllTakeLeavesByEmployeeIdEqual(int id)
        {
            return TakeLeaveDAO.GetAllTakeLeaveByEmployeeId(id);
        }

        public TakeLeave? GetTakeLeaveByDateBetweenAndEmployeeIdEqual(DateTime startDate, DateTime endDate, int employeeId)
        {
            return TakeLeaveDAO.GetTakeLeaveByDateBetweenAndEmployeeIdEqual(startDate, endDate, employeeId);
        }

        public TakeLeave? GetTakeLeaveById(int id)
        {
            return TakeLeaveDAO.GetTakeLeaveById(id);
        }

        public IEnumerable<TakeLeave> GetTakeLeaves()
        {
            return TakeLeaveDAO.GetTakeLeaves();
        }

        public void SaveTakeLeave(TakeLeave takeLeave)
        {
            TakeLeaveDAO.SaveTakeLeave(takeLeave);
        }

        public void UpdateTakeLeave(TakeLeave takeLeave)
        {
            TakeLeaveDAO.UpdateTakeLeave(takeLeave);
        }
    }
}
