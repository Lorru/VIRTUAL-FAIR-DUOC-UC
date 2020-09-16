package cl.virtualfair.models.virtualfair;

import java.io.Serializable;

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
	private long Id;
	
	@Column(name="ID_PURCHASE_REQUEST_TYPE")
	private long IdPurchaseRequestType;
	
	@Column(name="ID_PURCHASE_REQUEST_STATUS")
	private long IdPurchaseRequestStatus;
	
	@Column(name="ID_CLIENT")
	private long IdClient;
	
	@Column(name="TOTAL_WEIGHT")
	private Double TotalWeight;
	
	@Column(name="TOTAL_PRICE")
	private Long TotalPrice;
	
    @JoinColumn(name="ID_PURCHASE_REQUEST_TYPE", referencedColumnName="ID", insertable=false, updatable=false)
    @ManyToOne(fetch=FetchType.LAZY)
	private PurchaseRequestType PurchaseRequestType;
    
    @JoinColumn(name="ID_PURCHASE_REQUEST_STATUS", referencedColumnName="ID", insertable=false, updatable=false)
    @ManyToOne(fetch=FetchType.LAZY)
	private PurchaseRequestStatus PurchaseRequestStatus;
    
    @JoinColumn(name="ID_CLIENT", referencedColumnName="ID", insertable=false, updatable=false)
    @ManyToOne(fetch=FetchType.LAZY)
	private User Client;

	public PurchaseRequest() {
	}    
    
	public PurchaseRequest(long id) {
		Id = id;
	}

	public PurchaseRequest(long id, long idPurchaseRequestType, long idPurchaseRequestStatus, long idClient,
			Double totalWeight, Long totalPrice,
			cl.virtualfair.models.virtualfair.PurchaseRequestType purchaseRequestType,
			cl.virtualfair.models.virtualfair.PurchaseRequestStatus purchaseRequestStatus, User client) {
		Id = id;
		IdPurchaseRequestType = idPurchaseRequestType;
		IdPurchaseRequestStatus = idPurchaseRequestStatus;
		IdClient = idClient;
		TotalWeight = totalWeight;
		TotalPrice = totalPrice;
		PurchaseRequestType = purchaseRequestType;
		PurchaseRequestStatus = purchaseRequestStatus;
		Client = client;
	}

	public long getId() {
		return Id;
	}

	public void setId(long id) {
		Id = id;
	}

	public long getIdPurchaseRequestType() {
		return IdPurchaseRequestType;
	}

	public void setIdPurchaseRequestType(long idPurchaseRequestType) {
		IdPurchaseRequestType = idPurchaseRequestType;
	}

	public long getIdPurchaseRequestStatus() {
		return IdPurchaseRequestStatus;
	}

	public void setIdPurchaseRequestStatus(long idPurchaseRequestStatus) {
		IdPurchaseRequestStatus = idPurchaseRequestStatus;
	}

	public long getIdClient() {
		return IdClient;
	}

	public void setIdClient(long idClient) {
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
}
