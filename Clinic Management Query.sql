use Clinicmanagement

create Table users (username varchar(10) unique CONSTRAINT check_username check(username NOT LIKE '%[^a-zA-Z0-9]%'),
first_name varchar(30),last_name varchar(30),password varchar(30) CONSTRAINT check_password check(password like '%@%'));

insert into users values('Basid007','Basid','Safwan','basid@123')
insert into users values('Deepak008','Deepak','Kumar','deepak@123')
insert into users values('Santo009','Santo','Brighton','santo@123')
insert into users values('Atul006','Atul','Lakka','atul@123')



create table doctors (doctor_id int primary key, firstname varchar(20) constraint check_firstname check(firstname not like '%[^a-zA-Z0-9]%'), 
lastname varchar(20) constraint check_lastname check(lastname not like '%[^a-zA-Z0-9]%'), 
sex varchar(7), specialization varchar(50), visiting_from time,visiting_to time);

insert into doctors values(901,'Terry','Cook','M','General','11:00','12:00');
insert into doctors values(902,'Wanda','Bryant','F','Internal Medicine','9:00','11:00');
insert into doctors values(903,'Steven','Reed','M','Pediatrics','14:00','17:00');
insert into doctors values(904,'Alice','Cooper','F','Orthopedics','16:00','18:00');
insert into doctors values(905,'Edward','Anderson','M','ophthalmology','08:00','09:00');
truncate table doctors


create table patients (patient_id int identity(200,1) primary key, firstname varchar(20) constraint check_firstname_patient check(firstname not like '%[^a-zA-Z0-9]%'),
lastname varchar(20) constraint check_lastname_patient check(lastname not like '%[^a-zA-Z0-9]%'), sex varchar(7),
age int constraint check_age_patient check(age between 0 and 120), dob datetime)


insert into patients values(123,'rahul','mahesh','M',24,'2000/10/29')
select * from users
select * from doctors
select * from patients


create table appointments (apptid int identity(100,1) primary key,doctor_id int foreign key(doctor_id) 
references doctors(doctor_id),visitdate date,appttime varchar(30),apptstatus varchar(30),patient_id int foreign key references patients(patient_id));

select * from appointments

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
