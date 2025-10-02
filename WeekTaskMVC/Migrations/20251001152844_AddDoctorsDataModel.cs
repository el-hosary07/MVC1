using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeekTaskMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddDoctorsDataModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Doctors (Name, Specialization, Img) values ('Mellie Latchmore', 'Periodontist', 'doctor5.jpg');insert into Doctors (Name, Specialization, Img) values ('Freddi Danzey', 'Endodontist', 'doctor4.jpg');insert into Doctors (Name, Specialization, Img) values ('Orsola Southam', 'Periodontist', 'doctor6.jpg');insert into Doctors (Name, Specialization, Img) values ('Fraser Willavize', 'Endodontist', 'doctor6.jpg');insert into Doctors (Name, Specialization, Img) values ('Erminia Wharrier', 'Dentist', 'doctor1.jpg');insert into Doctors (Name, Specialization, Img) values ('Zerk Cain', 'Periodontist', 'doctor1.jpg');insert into Doctors (Name, Specialization, Img) values ('Aloysius MacSkeagan', 'Endodontist', 'doctor6.jpg');insert into Doctors (Name, Specialization, Img) values ('Titus Fetherby', 'Endodontist', 'doctor5.jpg');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE Doctors");
        }
    }
}
