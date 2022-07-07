CREATE PROCEDURE [dbo].[GetDoctorSpeciality]
	@param1 VARCHAR(100)
AS
BEGIN
IF(@param1 = 'SameHospitalDifferentSpeciality')
	BEGIN
		select 
			a.name, 
			a.Speciality,
			a.Hospital
		from
		Doctors a
		join (
			select 
				*
			from Doctors
		) as b
		on a.Hospital = b.Hospital
		and a.Speciality <> b.Speciality
		RETURN
	END
ELSE IF(@param1 = 'SameHospitalIrrespectiveSpeciality')
	BEGIN
		select 
			a.name,
			a.Speciality,
			a.Hospital
		from
		Doctors a
		join (
			select 
				*
			from Doctors
		) as b
		on 
		a.Id <> b.Id
		and
		a.Hospital = b.Hospital
		RETURN
	END
END
