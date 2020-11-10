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
@Table(name="TRANSPORT_AUCTION")
@Proxy(lazy=false)
public class TransportAuction implements Serializable {

	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.SEQUENCE ,generator="TRANSPORT_AUCTION_SEQ")
	@SequenceGenerator(name="TRANSPORT_AUCTION_SEQ", sequenceName="TRANSPORT_AUCTION_SEQ", allocationSize=1)
	@Column(name="ID")
	private Long Id;
	
	@Column(name="ID_PURCHASE_REQUEST")
	private Long IdPurchaseRequest;
	
	@Column(name="CREATION_DATE")
	private LocalDateTime CreationDate;
	
	@Column(name="UPDATE_DATE")
	private LocalDateTime UpdateDate;
	
	@Column(name="IS_PUBLIC")
	private Integer IsPublic;
	
    @JoinColumn(name="ID_PURCHASE_REQUEST", referencedColumnName="ID", insertable=false, updatable=false)
    @ManyToOne(fetch=FetchType.LAZY)
	private PurchaseRequest PurchaseRequest;

	public TransportAuction() {
	}
    
	public TransportAuction(Long id) {
		Id = id;
	}

	public TransportAuction(Long id, Long idPurchaseRequest, LocalDateTime creationDate, LocalDateTime updateDate,
			Integer isPublic, cl.virtualfair.models.virtualfair.PurchaseRequest purchaseRequest) {
		Id = id;
		IdPurchaseRequest = idPurchaseRequest;
		CreationDate = creationDate;
		UpdateDate = updateDate;
		IsPublic = isPublic;
		PurchaseRequest = purchaseRequest;
	}

	public Long getId() {
		return Id;
	}

	public void setId(Long id) {
		Id = id;
	}

	public Long getIdPurchaseRequest() {
		return IdPurchaseRequest;
	}

	public void setIdPurchaseRequest(Long idPurchaseRequest) {
		IdPurchaseRequest = idPurchaseRequest;
	}

	public LocalDateTime getCreationDate() {
		return CreationDate;
	}

	public void setCreationDate(LocalDateTime creationDate) {
		CreationDate = creationDate;
	}

	public LocalDateTime getUpdateDate() {
		return UpdateDate;
	}

	public void setUpdateDate(LocalDateTime updateDate) {
		UpdateDate = updateDate;
	}

	public Integer getIsPublic() {
		return IsPublic;
	}

	public void setIsPublic(Integer isPublic) {
		IsPublic = isPublic;
	}

	public PurchaseRequest getPurchaseRequest() {
		return PurchaseRequest;
	}

	public void setPurchaseRequest(PurchaseRequest purchaseRequest) {
		PurchaseRequest = purchaseRequest;
	}

	public static long getSerialversionuid() {
		return serialVersionUID;
	}
}
