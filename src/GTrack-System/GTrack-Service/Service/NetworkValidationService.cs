using System.Net;

namespace GTrack_Service.Service
{
    // NetworkValidationService is responsible for validating IP addresses and port numbers
    public class NetworkValidationService
    {
        // Method to validate if the given IP address is valid
        public bool IsValidIp(string ip)
        {
            // Try to parse the provided string into an IPAddress object
            if (IPAddress.TryParse(ip, out IPAddress ipAddr))
            {
                // Check if the IP address is of type IPv4 (InterNetwork)
                if (ipAddr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    // Split the IP address into its four segments (IPv4 addresses consist of four segments)
                    string[] segments = ip.Split('.');

                    // Ensure that the IP address has exactly 4 segments
                    if (segments.Length == 4)
                    {
                        // Check each segment to ensure it is a valid number between 0 and 255
                        foreach (var segment in segments)
                        {
                            // If the segment is not a valid integer or is out of the valid range (0-255), return false
                            if (!int.TryParse(segment, out int number) || number < 0 || number > 255)
                            {
                                return false;
                            }
                        }
                        return true; // Return true if all segments are valid
                    }
                }
            }
            return false; // Return false if IP address is invalid
        }

        // Method to validate if the given port number is within the valid range (1024-65535)
        public bool IsValidPort(string port)
        {
            // Try to parse the provided string into an integer (port number)
            if (int.TryParse(port, out int portNumber))
            {
                // Check if the port number is within the valid range of 1024 to 65535
                return portNumber >= 1024 && portNumber <= 65535;
            }
            return false; // Return false if the port number is invalid or out of range
        }

    }
}