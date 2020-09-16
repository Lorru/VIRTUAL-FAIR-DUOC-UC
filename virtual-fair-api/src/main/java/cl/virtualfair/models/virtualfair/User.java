package cl.virtualfair.models.virtualfair;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.SequenceGenerator;
import javax.persistence.Table;

import org.hibernate.annotations.Proxy;

import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;

@Entity
@Table(name="\"USER\"")
@Proxy(lazy=false)
public class User implements Serializable {

	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.SEQUENCE ,generator="USER_SEQ")
	@SequenceGenerator(name="USER_SEQ", sequenceName="USER_SEQ", allocationSize=1)
	@Column(name="ID")
	private long Id;
	
	@Column(name="ID_PROFILE")
	private long IdProfile;
	
	@Column(name="EMAIL")
	private String Email;
	
	@Column(name="FULL_NAME")
	private String FullName;
	
	@Column(name="COUNTRY")
	private String Country;
	
	@Column(name="CITY")
	private String City;
	
	@Column(name="ADDRESS")
	private String Address;
	
	@Column(name="PASSWORD")
	private String Password;
	
	@Column(name="STATUS")
	private int Status;

    @JoinColumn(name="ID_PROFILE", referencedColumnName="ID", insertable=false, updatable=false)
    @ManyToOne(fetch=FetchType.LAZY)
	private Profile Profile;
	
	public User() {
	}

	public User(long id) {
		Id = id;
	}

	public User(long id, long idProfile, String email, String fullName, String country, String city, String address,
			String password, int status, cl.virtualfair.models.virtualfair.Profile profile) {
		Id = id;
		IdProfile = idProfile;
		Email = email;
		FullName = fullName;
		Country = country;
		City = city;
		Address = address;
		Password = password;
		Status = status;
		Profile = profile;
	}

	public long getId() {
		return Id;
	}

	public void setId(long id) {
		Id = id;
	}

	public long getIdProfile() {
		return IdProfile;
	}

	public void setIdProfile(long idProfile) {
		IdProfile = idProfile;
	}

	public String getEmail() {
		return Email;
	}

	public void setEmail(String email) {
		Email = email;
	}

	public String getFullName() {
		return FullName;
	}

	public void setFullName(String fullName) {
		FullName = fullName;
	}

	public String getCountry() {
		return Country;
	}

	public void setCountry(String country) {
		Country = country;
	}

	public String getCity() {
		return City;
	}

	public void setCity(String city) {
		City = city;
	}

	public String getAddress() {
		return Address;
	}

	public void setAddress(String address) {
		Address = address;
	}

	public String getPassword() {
		return Password;
	}

	public void setPassword(String password) {
		Password = password;
	}

	public int getStatus() {
		return Status;
	}

	public void setStatus(int status) {
		Status = status;
	}

	public Profile getProfile() {
		return Profile;
	}

	public void setProfile(Profile profile) {
		Profile = profile;
	}
}
