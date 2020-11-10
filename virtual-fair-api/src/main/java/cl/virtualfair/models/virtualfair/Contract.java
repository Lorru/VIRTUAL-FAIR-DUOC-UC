package cl.virtualfair.models.virtualfair;

import java.io.Serializable;
import java.time.LocalDateTime;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.SequenceGenerator;
import javax.persistence.Table;

import org.hibernate.annotations.Proxy;

@Entity
@Table(name="CONTRACT")
@Proxy(lazy=false)
public class Contract implements Serializable {

	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.SEQUENCE ,generator="CONTRACT_SEQ")
	@SequenceGenerator(name="CONTRACT_SEQ", sequenceName="CONTRACT_SEQ", allocationSize=1)
	@Column(name="ID")
	private Long Id;
	
	@Column(name="ID_USER")
	private Long IdUser;
	
	@Column(name="CREATION_DATE")
	private LocalDateTime CreationDate;
	
	@Column(name="EXPIRATION_DATE")
	private LocalDateTime ExpirationDate;
	
	@Column(name="IS_VALID")
	private Integer IsValid;
	
    @JoinColumn(name="ID_USER", referencedColumnName="ID", insertable=false, updatable=false)
    @ManyToOne(fetch=FetchType.LAZY)
	private User User;

	@javax.persistence.Transient
	private String ContractPath;
    
	public Contract() {
	}    
    
	public Contract(Long id) {
		Id = id;
	}

	public Contract(Long id, Long idUser, String contractPath, LocalDateTime creationDate, LocalDateTime expirationDate,
			Integer isValid, cl.virtualfair.models.virtualfair.User user) {
		Id = id;
		IdUser = idUser;
		ContractPath = contractPath;
		CreationDate = creationDate;
		ExpirationDate = expirationDate;
		IsValid = isValid;
		User = user;
	}

	public Long getId() {
		return Id;
	}

	public void setId(Long id) {
		Id = id;
	}

	public Long getIdUser() {
		return IdUser;
	}

	public void setIdUser(Long idUser) {
		IdUser = idUser;
	}

	public String getContractPath() {
		return ContractPath;
	}

	public void setContractPath(String contractPath) {
		ContractPath = contractPath;
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

	public Integer getIsValid() {
		return IsValid;
	}

	public void setIsValid(Integer isValid) {
		IsValid = isValid;
	}

	public User getUser() {
		return User;
	}

	public void setUser(User user) {
		User = user;
	}
}
