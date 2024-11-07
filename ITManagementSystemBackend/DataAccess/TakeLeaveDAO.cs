using BusinessObject;
using Microsoft.EntityFrameworkCore;
using static BusinessObject.Enum.EnumList;

namespace DataAccess
{
    public class TakeLeaveDAO
    {
        private static readonly List<DateTime> publicHolidays = new List<DateTime>
        {
            new DateTime(2023, 1, 1),    // New Year's Day
            new DateTime(2023, 2, 10),   // Lunar New Year's Eve
            new DateTime(2023, 2, 11),   // Lunar New Year (Day 1)
            new DateTime(2023, 2, 12),   // Lunar New Year (Day 2)
            new DateTime(2023, 2, 13),   // Lunar New Year (Day 3)
            new DateTime(2023, 2, 14),   // Lunar New Year (Day 4)
            new DateTime(2023, 4, 25),   // Reunification Day
            new DateTime(2023, 5, 1),    // Labor Day
            new DateTime(2023, 9, 2),    // National Day
        };

        public static int CalculateLeaveDays(DateTime startDate, DateTime endDate)
        {
            int leaveDays = 0;
            DateTime currentDate = startDate;

            while (currentDate.Date <= endDate.Date)
            {
                if (currentDate.DayOfWeek != DayOfWeek.Saturday &&
                    currentDate.DayOfWeek != DayOfWeek.Sunday &&
                    !IsPublicHoliday(currentDate, publicHolidays))
                {
                    leaveDays++;
                }
                currentDate = currentDate.AddDays(1);
            }

            return leaveDays;
        }

        private static bool IsPublicHoliday(DateTime date, List<DateTime> publicHolidays)
        {
            foreach (DateTime holiday in publicHolidays)
            {
                if (date.Date == holiday.Date)
                {
                    return true;
                }
            }
            return false;
        }


        public static TakeLeave? GetTakeLeaveById(int id)
        {
            using MyDbContext context = new();
            return context.TakeLeaves.FirstOrDefault(x => x.Id == id);
        }

        public static void DeleteTakeLeave(TakeLeave takeLeave)
        {
            using var context = new MyDbContext();
            context.TakeLeaves.Remove(takeLeave);
            context.SaveChanges();
        }

        public static IEnumerable<TakeLeave> GetAllTakeLeaveByDayBetween(DateTime startDate, DateTime endDate)
        {
            using var context = new MyDbContext();
            return context.TakeLeaves.Where(tl => tl.StartDate.Date <= endDate.Date && startDate.Date <= tl.EndDate.Date)
                .OrderByDescending(o => o.Id).ToList();
        }

        public static IEnumerable<TakeLeave> GetAllTakeLeaveByEmployeeId(int id)
        {
            using var context = new MyDbContext();
            return context.TakeLeaves
                .Where(tl => tl.EmployeeId == id && !tl.Status.Equals(TakeLeaveStatus.DELETED))
                .OrderByDescending(o => o.Id);
        }

        public static TakeLeave? GetTakeLeaveByDateBetweenAndEmployeeIdEqual(DateTime startDate, DateTime endDate, int employeeId)
        {
            using var context = new MyDbContext();
            return context
                .TakeLeaves
                .Include(tl => tl.User)
                .FirstOrDefault(tl => tl.StartDate.Date <= endDate.Date && startDate.Date <= tl.EndDate.Date && tl.EmployeeId == employeeId && tl.Status.Equals(TakeLeaveStatus.APPROVED));
        }

        public static IEnumerable<TakeLeave> GetTakeLeaves()
        {
            using var context = new MyDbContext();
            return context.TakeLeaves.Include(tl => tl.User).OrderByDescending(o => o.Id).ToList();
        }

        public static void SaveTakeLeave(TakeLeave takeLeave)
        {
            using var context = new MyDbContext();
            context.TakeLeaves.Add(takeLeave);
            context.SaveChanges();
        }

        public static void UpdateTakeLeave(TakeLeave takeLeave)
        {
            using var context = new MyDbContext();
            context.TakeLeaves.Update(takeLeave);
            context.SaveChanges();
        }

        public static int CalculateLeaveDaysByEmployeeIdEqualAndYearEqual(int employeeId, int year)
        {
            using var context = new MyDbContext();
            return context.TakeLeaves
            .Where(tl => tl.StartDate.Year == year && tl.EmployeeId == employeeId
                && tl.Type == TakeLeaveType.ANNUAL_LEAVE && tl.Status == TakeLeaveStatus.APPROVED)
            .Sum(tl => tl.LeaveDays);
        }

        public static int CalculateLeaveDaysByEmployeeIdEqualAndMonthEqualAndYearEqual(int employeeId, DateTime startDate, DateTime endDate)
        {
            using var context = new MyDbContext();
            var result = context.TakeLeaves
                .Where(tl => tl.StartDate.Date <= endDate.Date && startDate.Date <= tl.EndDate.Date
                    && tl.EmployeeId == employeeId && tl.Type != TakeLeaveType.UNPAID_LEAVE && tl.Status == TakeLeaveStatus.APPROVED)
                .AsEnumerable()
                .Select(tl => CalculateAdjustedLeaveDays(tl, startDate, endDate))
                .Sum();

            return result;
        }

        private static int CalculateAdjustedLeaveDays(TakeLeave tl, DateTime startDate, DateTime endDate)
        {
            DateTime adjustedStartDate = tl.StartDate.Date > startDate.Date ? tl.StartDate : startDate;
            DateTime adjustedEndDate = tl.EndDate.Date < endDate.Date ? tl.EndDate : endDate;
            return CalculateLeaveDays(adjustedStartDate, adjustedEndDate);
        }


        public static bool ExistApprovedAttendanceByDateEqualAndEmployeeEqual(int employeeId, DateTime startDate, DateTime endDate)
        {
            using var context = new MyDbContext();
            return context.Attendances
            .Any(a => a.Date.Date >= startDate.Date && a.Date.Date <= endDate.Date
                && a.EmployeeId == employeeId && a.Status == AttendanceStatus.Approved);
        }
    }
}
