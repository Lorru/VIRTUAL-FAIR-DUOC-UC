package cl.virtualfair.models.virtualfair;

import java.io.Serializable;
import java.time.LocalDateTime;
import java.util.List;

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
@Table(name="PURCHASE_REQUEST")
@Proxy(lazy=false)
public class PurchaseRequest implements Serializable {

	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.SEQUENCE ,generator="PURCHASE_REQUEST_SEQ")
	@SequenceGenerator(name="PURCHASE_REQUEST_SEQ", sequenceName="PURCHASE_REQUEST_SEQ", allocationSize=1)
	@Column(name="ID")
	private Long Id;
	
	@Column(name="ID_PURCHASE_REQUEST_TYPE")
	private Long IdPurchaseRequestType;
	
	@Column(name="ID_PURCHASE_REQUEST_STATUS")
	private Long IdPurchaseRequestStatus;
	
	@Column(name="ID_CLIENT")
	private Long IdClient;
	
	@Column(name="TOTAL_WEIGHT")
	private Double TotalWeight;
	
	@Column(name="TOTAL_PRICE")
	private Long TotalPrice;

	@Column(name="DESIRED_DATE")
	private LocalDateTime DesiredDate;
	
	@Column(name="CREATION_DATE")
	private LocalDateTime CreationDate;
	
	@Column(name="UPDATE_DATE")
	private LocalDateTime UpdateDate;
	
	@Column(name="IS_PUBLIC")
	private Integer IsPublic;
	
    @JoinColumn(name="ID_PURCHASE_REQUEST_TYPE", referencedColumnName="ID", insertable=false, updatable=false)
    @ManyToOne(fetch=FetchType.LAZY)
	private PurchaseRequestType PurchaseRequestType;
    
    @JoinColumn(name="ID_PURCHASE_REQUEST_STATUS", referencedColumnName="ID", insertable=false, updatable=false)
    @ManyToOne(fetch=FetchType.LAZY)
	private PurchaseRequestStatus PurchaseRequestStatus;
    
    @JoinColumn(name="ID_CLIENT", referencedColumnName="ID", insertable=false, updatable=false)
    @ManyToOne(fetch=FetchType.LAZY)
	private User Client;

    @javax.persistence.Transient
    private List<PurchaseRequestProduct> PurchaseRequestProducts;

	public PurchaseRequest() {
	}    
    
	public PurchaseRequest(Long id) {
		Id = id;
	}

	public PurchaseRequest(Long id, Long idPurchaseRequestType, Long idPurchaseRequestStatus, Long idClient,
			Double totalWeight, Long totalPrice, LocalDateTime desiredDate, LocalDateTime creationDate,
			LocalDateTime updateDate, Integer isPublic,
			cl.virtualfair.models.virtualfair.PurchaseRequestType purchaseRequestType,
			cl.virtualfair.models.virtualfair.PurchaseRequestStatus purchaseRequestStatus, User client,
			List<PurchaseRequestProduct> purchaseRequestProducts) {
		Id = id;
		IdPurchaseRequestType = idPurchaseRequestType;
		IdPurchaseRequestStatus = idPurchaseRequestStatus;
		IdClient = idClient;
		TotalWeight = totalWeight;
		TotalPrice = totalPrice;
		DesiredDate = desiredDate;
		CreationDate = creationDate;
		UpdateDate = updateDate;
		IsPublic = isPublic;
		PurchaseRequestType = purchaseRequestType;
		PurchaseRequestStatus = purchaseRequestStatus;
		Client = client;
		PurchaseRequestProducts = purchaseRequestProducts;
	}

	public Long getId() {
		return Id;
	}

	public void setId(Long id) {
		Id = id;
	}

	public Long getIdPurchaseRequestType() {
		return IdPurchaseRequestType;
	}

	public void setIdPurchaseRequestType(Long idPurchaseRequestType) {
		IdPurchaseRequestType = idPurchaseRequestType;
	}

	public Long getIdPurchaseRequestStatus() {
		return IdPurchaseRequestStatus;
	}

	public void setIdPurchaseRequestStatus(Long idPurchaseRequestStatus) {
		IdPurchaseRequestStatus = idPurchaseRequestStatus;
	}

	public Long getIdClient() {
		return IdClient;
	}

	public void setIdClient(Long idClient) {
		IdClient = idClient;
	}

	public Double getTotalWeight() {
		return TotalWeight;
	}

	public void setTotalWeight(Double totalWeight) {
		TotalWeight = totalWeight;
	}

	public Long getTotalPrice() {
		return TotalPrice;
	}

	public void setTotalPrice(Long totalPrice) {
		TotalPrice = totalPrice;
	}

	public LocalDateTime getDesiredDate() {
		return DesiredDate;
	}

	public void setDesiredDate(LocalDateTime desiredDate) {
		DesiredDate = desiredDate;
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

	public PurchaseRequestType getPurchaseRequestType() {
		return PurchaseRequestType;
	}

	public void setPurchaseRequestType(PurchaseRequestType purchaseRequestType) {
		PurchaseRequestType = purchaseRequestType;
	}

	public PurchaseRequestStatus getPurchaseRequestStatus() {
		return PurchaseRequestStatus;
	}

	public void setPurchaseRequestStatus(PurchaseRequestStatus purchaseRequestStatus) {
		PurchaseRequestStatus = purchaseRequestStatus;
	}

	public User getClient() {
		return Client;
	}

	public void setClient(User client) {
		Client = client;
	}

	public List<PurchaseRequestProduct> getPurchaseRequestProducts() {
		return PurchaseRequestProducts;
	}

	public void setPurchaseRequestProducts(List<PurchaseRequestProduct> purchaseRequestProducts) {
		PurchaseRequestProducts = purchaseRequestProducts;
	}
}
