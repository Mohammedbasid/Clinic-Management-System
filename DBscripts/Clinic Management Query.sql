use Clinicmanagement

--creating users Table

create Table users (username varchar(10) unique CONSTRAINT check_username check(username NOT LIKE '%[^a-zA-Z0-9]%'),
first_name varchar(30),last_name varchar(30),password varchar(30) CONSTRAINT check_password check(password like '%@%'));

--inserting the user Values

insert into users values('Basid007','Basid','Safwan','basid@123')
insert into users values('Deepak008','Deepak','Kumar','deepak@123')
insert into users values('Santo009','Santo','Brighton','santo@123')
insert into users values('Atul006','Atul','Lakka','atul@123')

--Displaying all the users

select * from users

--Creating Doctors Table
create table doctors (doctor_id int primary key, firstname varchar(20) constraint check_firstname check(firstname not like '%[^a-zA-Z0-9]%'), 
lastname varchar(20) constraint check_lastname check(lastname not like '%[^a-zA-Z0-9]%'), 
sex varchar(7), specialization varchar(50), visiting_from time,visiting_to time);

--Inserting  Doctor Values
insert into doctors values(901,'Terry','Cook','M','General','11:00','12:00');
insert into doctors values(902,'Wanda','Bryant','F','Internal Medicine','9:00','11:00');
insert into doctors values(903,'Steven','Reed','M','Pediatrics','14:00','17:00');
insert into doctors values(904,'Alice','Cooper','F','Orthopedics','16:00','18:00');
insert into doctors values(905,'Edward','Anderson','M','ophthalmology','08:00','09:00');

--To Display all the Doctors
select * from doctors


--Creating Patients Table
create table patients (patient_id int identity(200,1) primary key, firstname varchar(20) constraint check_firstname_patient check(firstname not like '%[^a-zA-Z0-9]%'),
lastname varchar(20) constraint check_lastname_patient check(lastname not like '%[^a-zA-Z0-9]%'), sex varchar(7),
age int constraint check_age_patient check(age between 0 and 120), dob datetime)

--To Display all the Patients
select * from patients

--Creating Appointment Table
create table appointments (apptid int identity(100,1) primary key,doctor_id int foreign key(doctor_id) 
references doctors(doctor_id),visitdate date,appttime varchar(30),apptstatus varchar(30),patient_id int foreign key references patients(patient_id));


--Inserting all the Appointment Slots from the date 26/08/2022 to 10/09/2022

insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(901,'2022-08-26','11-12','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(902,'2022-08-26','09-10','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(902,'2022-08-26','10-11','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-08-26','14-15','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-08-26','15-16','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-08-26','16-17','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(904,'2022-08-26','16-17','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(904,'2022-08-26','17-18','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(905,'2022-08-26','08-09','Available',null);

insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(901,'2022-08-27','11-12','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(902,'2022-08-27','09-10','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(902,'2022-08-27','10-11','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-08-27','14-15','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-08-27','15-16','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-08-27','16-17','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(904,'2022-08-27','16-17','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(904,'2022-08-27','17-18','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(905,'2022-08-27','08-09','Available',null);

insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(901,'2022-08-28','11-12','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(902,'2022-08-28','09-10','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(902,'2022-08-28','10-11','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-08-28','14-15','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-08-28','15-16','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-08-28','16-17','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(904,'2022-08-28','16-17','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(904,'2022-08-28','17-18','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(905,'2022-08-28','08-09','Available',null);

insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(901,'2022-08-29','11-12','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(902,'2022-08-29','09-10','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(902,'2022-08-29','10-11','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-08-29','14-15','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-08-29','15-16','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-08-29','16-17','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(904,'2022-08-29','16-17','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(904,'2022-08-29','17-18','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(905,'2022-08-29','08-09','Available',null);

insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(901,'2022-08-30','11-12','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(902,'2022-08-30','09-10','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(902,'2022-08-30','10-11','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-08-30','14-15','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-08-30','15-16','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-08-30','16-17','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(904,'2022-08-30','16-17','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(904,'2022-08-30','17-18','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(905,'2022-08-30','08-09','Available',null);

insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(901,'2022-08-31','11-12','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(902,'2022-08-31','09-10','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(902,'2022-08-31','10-11','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-08-31','14-15','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-08-31','15-16','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-08-31','16-17','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(904,'2022-08-31','16-17','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(904,'2022-08-31','17-18','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(905,'2022-08-31','08-09','Available',null);

insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(901,'2022-09-01','11-12','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(902,'2022-09-01','09-10','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(902,'2022-09-01','10-11','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-09-01','14-15','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-09-01','15-16','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-09-01','16-17','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(904,'2022-09-01','16-17','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(904,'2022-09-01','17-18','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(905,'2022-09-01','08-09','Available',null);

insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(901,'2022-09-02','11-12','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(902,'2022-09-02','09-10','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(902,'2022-09-02','10-11','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-09-02','14-15','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-09-02','15-16','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-09-02','16-17','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(904,'2022-09-02','16-17','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(904,'2022-09-02','17-18','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(905,'2022-09-02','08-09','Available',null);

insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(901,'2022-09-03','11-12','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(902,'2022-09-03','09-10','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(902,'2022-09-03','10-11','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-09-03','14-15','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-09-03','15-16','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-09-03','16-17','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(904,'2022-09-03','16-17','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(904,'2022-09-03','17-18','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(905,'2022-09-03','08-09','Available',null);

insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(901,'2022-09-04','11-12','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(902,'2022-09-04','09-10','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(902,'2022-09-04','10-11','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-09-04','14-15','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-09-04','15-16','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-09-04','16-17','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(904,'2022-09-04','16-17','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(904,'2022-09-04','17-18','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(905,'2022-09-04','08-09','Available',null);

insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(901,'2022-09-05','11-12','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(902,'2022-09-05','09-10','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(902,'2022-09-05','10-11','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-09-05','14-15','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-09-05','15-16','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-09-05','16-17','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(904,'2022-09-05','16-17','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(904,'2022-09-05','17-18','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(905,'2022-09-05','08-09','Available',null);

insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(901,'2022-09-06','11-12','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(902,'2022-09-06','09-10','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(902,'2022-09-06','10-11','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-09-06','14-15','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-09-06','15-16','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-09-06','16-17','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(904,'2022-09-06','16-17','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(904,'2022-09-06','17-18','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(905,'2022-09-06','08-09','Available',null);


insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(901,'2022-09-07','11-12','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(902,'2022-09-07','09-10','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(902,'2022-09-07','10-11','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-09-07','14-15','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-09-07','15-16','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-09-07','16-17','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(904,'2022-09-07','16-17','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(904,'2022-09-07','17-18','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(905,'2022-09-07','08-09','Available',null);

insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(901,'2022-09-08','11-12','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(902,'2022-09-08','09-10','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(902,'2022-09-08','10-11','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-09-08','14-15','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-09-08','15-16','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-09-08','16-17','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(904,'2022-09-08','16-17','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(904,'2022-09-08','17-18','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(905,'2022-09-08','08-09','Available',null);

insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(901,'2022-09-09','11-12','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(902,'2022-09-09','09-10','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(902,'2022-09-09','10-11','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-09-09','14-15','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-09-09','15-16','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-09-09','16-17','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(904,'2022-09-09','16-17','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(904,'2022-09-09','17-18','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(905,'2022-09-09','08-09','Available',null);

insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(901,'2022-09-10','11-12','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(902,'2022-09-10','09-10','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(902,'2022-09-10','10-11','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-09-10','14-15','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-09-10','15-16','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(903,'2022-09-10','16-17','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(904,'2022-09-10','16-17','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(904,'2022-09-10','17-18','Available',null);
insert into appointments(doctor_id,visitdate,appttime,apptstatus,patient_id) values(905,'2022-09-10','08-09','Available',null);

--To Display all the Appointments
select * from appointments


