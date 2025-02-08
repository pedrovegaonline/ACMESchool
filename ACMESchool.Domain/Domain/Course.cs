namespace ACMESchool.Production.Domain
{
    public class Course
    {
        /// <summary>
        /// Full name of the course.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Registration fee for the course.
        /// </summary>
        public decimal RegistrationFee { get; set; }

        /// <summary>
        /// Start date of the course.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End date of the course.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// List of students enrolled in the course.
        /// </summary>
        public List<Student> Students { get; internal set; }

        /// <summary>
        /// Indicates if the course is free.
        /// </summary>
        public bool IsFree => RegistrationFee == 0;
    }
}