using SportConnect.Core.Model.User;
using SportConnect.Core.Services.User;
using SportConnect.Core.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SportConnect.Core.ViewModels.MainApplications.Admin.UsersList
{
    public class UserLogRecordsViewModel : BaseViewModel
    {
        private readonly UserService _userService;

        public ObservableCollection<UserLogRecordModel> UserLogRecordModelList { get; set; }

        public UserLogRecordsViewModel(UserService userService)
        {
            _userService = userService;
            UserLogRecordModelList = new ObservableCollection<UserLogRecordModel>();

            FillUserLogRecordList().GetAwaiter();
            Task.WaitAll();
        }

        private async Task FillUserLogRecordList()
        {
            var usersLogRecords = await _userService.GetUserLogRecords();

            var rowNumber = 1;

            foreach (var logRecord in usersLogRecords)
            {
                logRecord.RowNumber = rowNumber;
                UserLogRecordModelList.Add(logRecord);
                rowNumber++;
            }
        }
    }
}
