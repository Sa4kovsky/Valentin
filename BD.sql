--DROP TABLE Patient, Inoculations, ChronicDiseases,Ultrasonography,LaboratoryResearch,Diseases,DiseasesAndSymptoms,DiseasesAndLaboratoryResearch,DiseasesAndUltrasonography;



CREATE TABLE Patient(
	idPatient SERIAL PRIMARY KEY,  --идентифицирующий ключ
	photo text, --путь к фото пациента
	namePatient text,  --имя пициента
	birthday date, --день рождения
	address text, --адрес проживания
	phone text, --номер телефона
	email text, --почта
	work text --место работы
);

CREATE TABLE Inoculations(
	idInoculations SERIAL PRIMARY KEY,  --идентифицирующий ключ
	idPatient integer, --ключ таблицы "Patient"
	title text, --название прививки
	date date, --дата прививки
	note text, --примеание

	FOREIGN KEY (idPatient) REFERENCES Patient(idPatient) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE CASCADE
);

CREATE TABLE ChronicDiseases(
	idChronicDiseases SERIAL PRIMARY KEY,  --идентифицирующий ключ
	idPatient integer, --ключ таблицы "Patient"
	title text, --название хронические заболевания
	date date, --дата хронические заболевания
	note text, --примеание

	FOREIGN KEY (idPatient) REFERENCES Patient(idPatient) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE CASCADE
);

CREATE TABLE Ultrasonography(
	idUltrasonography SERIAL PRIMARY KEY,  --идентифицирующий ключ
	idPatient integer, --ключ таблицы "Patient"
	title text, --название хронические заболевания
	date date, --дата УЗИ
	data text, --даные УЗИ
	conclusion text, --заключение

	FOREIGN KEY (idPatient) REFERENCES Patient(idPatient) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE CASCADE
);

CREATE TABLE LaboratoryResearch(
	idLaboratoryResearch SERIAL PRIMARY KEY,  --идентифицирующий ключ
	idPatient integer, --ключ таблицы "Patient"
	title text, --название хронические заболевания
	date date, --дата Анализов
	data text, --даные Анализов
	conclusion text, --заключение

	FOREIGN KEY (idPatient) REFERENCES Patient(idPatient) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE CASCADE
);

CREATE TABLE Diseases(
	idDiseases SERIAL PRIMARY KEY,  --идентифицирующий ключ
	idPatient integer, --ключ таблицы "Patient"
	date date, --дата выдачи диагноза
	diagnosis text, --диагноз
	treatment text, --лечение(лекарство, процедуры)

	FOREIGN KEY (idPatient) REFERENCES Patient(idPatient) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE CASCADE
);

CREATE TABLE Symptoms(
	idSymptoms SERIAL PRIMARY KEY,  --идентифицирующий ключ
	idPatient integer, --ключ таблицы "Patient"
	title text,
	date date,

	FOREIGN KEY (idPatient) REFERENCES Patient(idPatient) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE CASCADE
);

CREATE TABLE DiseasesAndSymptoms(
	id SERIAL PRIMARY KEY,  --идентифицирующий ключ
	idDiseases integer, 
	idSymptoms integer,

	FOREIGN KEY (idDiseases) REFERENCES Diseases(idDiseases) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE CASCADE,
	FOREIGN KEY (idSymptoms) REFERENCES Symptoms(idSymptoms) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE CASCADE
);

CREATE TABLE DiseasesAndLaboratoryResearch(
	id SERIAL PRIMARY KEY,  --идентифицирующий ключ
	idDiseases integer, 
	idLaboratoryResearch integer,

	FOREIGN KEY (idDiseases) REFERENCES Diseases(idDiseases)  MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE CASCADE,
	FOREIGN KEY (idLaboratoryResearch) REFERENCES LaboratoryResearch(idLaboratoryResearch)  MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE CASCADE
);

CREATE TABLE DiseasesAndUltrasonography(
	id SERIAL PRIMARY KEY,  --идентифицирующий ключ
	idDiseases integer, 
	idUltrasonography integer,

	FOREIGN KEY (idDiseases) REFERENCES Diseases(idDiseases)  MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE CASCADE,
	FOREIGN KEY (idUltrasonography) REFERENCES Ultrasonography(idUltrasonography)  MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE CASCADE
);
