using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCompany_TestApp
{
    public partial class Empoyee
    {
        /// <summary>
        /// Compares every other field except ID, depID, docNumber, docSeries and position
        /// </summary>
        public bool HasSamePersonalInfoAs(Empoyee emp)
        {
            if (emp == null) return false;
            if (SurName != emp.SurName) return false;
            if (FirstName != emp.FirstName) return false;

            bool emptyPatr = string.IsNullOrEmpty(Patronymic);
            bool empEmptyPatr = string.IsNullOrEmpty(emp.Patronymic);
            if (emptyPatr != empEmptyPatr) return false;
            if (!emptyPatr && !empEmptyPatr && Patronymic != emp.Patronymic) return false;

            if (DateOfBirth != emp.DateOfBirth) return false;
            return true;
        }

        /// <returns>If any of the docs are empty returns false</returns>
        public bool HasSameDocsAs(Empoyee emp)
        {
            bool empNumIsEmpty = string.IsNullOrEmpty(emp.DocNumber);
            bool empSeriesIsEmpty = string.IsNullOrEmpty(emp.DocSeries);
            bool numIsEmpty = string.IsNullOrEmpty(DocNumber);
            bool seriesIsEmpty = string.IsNullOrEmpty(DocSeries);

            var sameSeries = (seriesIsEmpty && empSeriesIsEmpty) || emp.DocSeries == DocSeries;
            var sameNumber = (numIsEmpty && empNumIsEmpty) || emp.DocNumber == DocNumber;
            return sameSeries && sameNumber;
        }

        public bool HasEmptyDocFields()
        {
            var numbIsEmpty = string.IsNullOrEmpty(DocNumber);
            var seriesIsEmpty = string.IsNullOrEmpty(DocSeries);
            return numbIsEmpty || seriesIsEmpty;
        }
    }
}
