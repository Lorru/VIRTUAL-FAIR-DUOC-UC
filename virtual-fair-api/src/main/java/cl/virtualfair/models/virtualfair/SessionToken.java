package cl.virtualfair.models.virtualfair;

import java.io.Serializable;
import java.time.LocalDateTime;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.SequenceGenerator;
import javax.persistence.Table;

import org.hibernate.annotations.Proxy;

@Entity
@Table(name="SESSION_TOKEN")
@Proxy(lazy=false)
public class SessionToken implements Serializable {

	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.SEQUENCE ,generator="SESSION_TOKEN_SEQ")
	@SequenceGenerator(name="SESSION_TOKEN_SEQ", sequenceName="SESSION_TOKEN_SEQ", allocationSize=1)
	@Column(name="ID")
	private long Id;
	
	@Column(name="ID_USER")
	private long IdUser;
	
	@Column(name="TOKEN")
	private String Token;
	
	@Column(name="HOST")
	private String Host;
	
	@Column(name="CREATION_DATE")
	private LocalDateTime CreationDate;
	
	@Column(name="EXPIRATION_DATE")
	private LocalDateTime ExpirationDate;
	
	public SessionToken() {
		
	}

	public SessionToken(long id) {
		Id = id;
	}

	public SessionToken(long id, long idUser, String token, String host, LocalDateTime creationDate, LocalDateTime expirationDate) {
		Id = id;
		IdUser = idUser;
		Token = token;
		Host = host;
		CreationDate = creationDate;
		ExpirationDate = expirationDate;
	}

	public long getId() {
		return Id;
	}

	public void setId(long id) {
		Id = id;
	}

	public long getIdUser() {
		return IdUser;
	}

	public void setIdUser(long idUser) {
		IdUser = idUser;
	}

	public String getToken() {
		return Token;
	}

	public void setToken(String token) {
		Token = token;
	}

	public String getHost() {
		return Host;
	}

	public void setHost(String host) {
		Host = host;
	}

	public LocalDateTime getCreationDate() {
		return CreationDate;
	}

	public void setCreationDate(LocalDateTime creationDate) {
		CreationDate = creationDate;
	}

	public LocalDateTime getExpirationDate() {
		return ExpirationDate;
	}

	public void setExpirationDate(LocalDateTime expirationDate) {
		ExpirationDate = expirationDate;
	}
}
