using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vmAgent
{
    public class Booking
    {
        private int id = 0;
        private int bookType = 0;
        private string userId = "";
        private string userName = "";
        private DateTime bookStart;
        private DateTime bookEnd;
        private int bookRegion = 0;
        private int bookPool = 0;
        private int bookGroup = 0;
        private string agentName = "";
        private int status = 0;
        private string description = "";
        private string remarks = string.Empty;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public int BookType
        {
            get
            {
                return bookType;
            }

            set
            {
                bookType = value;
            }
        }

        public string UserId
        {
            get
            {
                return userId;
            }

            set
            {
                userId = value;
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public DateTime BookStart
        {
            get
            {
                return bookStart;
            }

            set
            {
                bookStart = value;
            }
        }

        public DateTime BookEnd
        {
            get
            {
                return bookEnd;
            }

            set
            {
                bookEnd = value;
            }
        }

        public int BookRegion
        {
            get
            {
                return bookRegion;
            }

            set
            {
                bookRegion = value;
            }
        }

        public int BookPool
        {
            get
            {
                return bookPool;
            }

            set
            {
                bookPool = value;
            }
        }

        public int BookGroup
        {
            get
            {
                return bookGroup;
            }

            set
            {
                bookGroup = value;
            }
        }

        public string AgentName
        {
            get
            {
                return agentName;
            }

            set
            {
                agentName = value;
            }
        }

        public int Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public string Remarks
        {
            get
            {
                return remarks;
            }

            set
            {
                remarks = value;
            }
        }
    }
}
