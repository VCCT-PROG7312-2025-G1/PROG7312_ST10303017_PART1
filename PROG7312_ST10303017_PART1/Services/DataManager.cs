using PROG7312_ST10303017_PART1.DataStructures;
using PROG7312_ST10303017_PART1.Models;

namespace PROG7312_ST10303017_PART1.Services
{
    public static class DataManager
    {
        // In-memory storage for users and service requests
        private static readonly CustomLinkedList<User> _users = new CustomLinkedList<User>();
        private static readonly CustomLinkedList<ServiceRequest> _serviceRequests = new CustomLinkedList<ServiceRequest>();

        public static User CurrentUser { get; private set; }//

        static DataManager()
        {
            // Add sample users
            _users.Add(new User { Username = "calwyn", Password = "calwyn123", FullName = "Calwyn Govender" });
            _users.Add(new User { Username = "lewis", Password = "lewis123", FullName = "Lewis Hamilton" });
            _users.Add(new User { Username = "lebron", Password = "lebron123", FullName = "LeBron James" });

            // Add sample service requests
            _serviceRequests.Add(new ServiceRequest
            {
                TrackingId = "WR-2024-001",
                Category = "Pothole",
                Status = "Resolved",
                SubmittedByUsername = "lewis",
                SubmittedDate = DateTime.Now.AddDays(-10),
                Description = "Large pothole on Amber Street causing traffic issues."
            });
            _serviceRequests.Add(new ServiceRequest
            {
                TrackingId = "WR-2024-002",
                Category = "Water Leak",
                Status = "Work in Progress",
                SubmittedByUsername = "lebron",
                SubmittedDate = DateTime.Now.AddDays(-2),
                Description = "Constant water leak near the park."
            });
            _serviceRequests.Add(new ServiceRequest
            {
                TrackingId = "WR-2024-003",
                Category = "Pothole",
                Status = "Submitted",
                SubmittedByUsername = "calwyn",
                SubmittedDate = DateTime.Now.AddDays(-1),
                Description = "Another pothole forming on West Street."
            });
        }

        // Validates user credentials and sets the current user if valid
        public static bool ValidateUser(string username, string password)
        {
            foreach (var user in _users)
            {
                if (user.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && user.Password == password)
                {
                    CurrentUser = user;
                    return true;
                }
            }
            return false;
        }

        public static void Logout() => CurrentUser = null;

        // Submits a new service request
        public static void SubmitNewRequest(ServiceRequest request)
        {
            request.TrackingId = $"WR-{DateTime.Now.Year}-{_serviceRequests.Count + 1:000}";
            _serviceRequests.Add(request);
        }

        // Retrieves all service requests submitted by the current user
        public static CustomLinkedList<ServiceRequest> GetRequestsForCurrentUser()
        {
            var userRequests = new CustomLinkedList<ServiceRequest>();
            if (CurrentUser == null) return userRequests;

            foreach (var request in _serviceRequests)
            {
                if (request.SubmittedByUsername.Equals(CurrentUser.Username, StringComparison.OrdinalIgnoreCase))
                {
                    userRequests.Add(request);
                }
            }
            return userRequests;
        }
    }
}
