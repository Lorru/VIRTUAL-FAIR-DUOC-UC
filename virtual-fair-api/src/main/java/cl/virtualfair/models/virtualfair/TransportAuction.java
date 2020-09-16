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
	private long Id;
	
	@Column(name="ID_PURCHASE_REQUEST")
	private long IdPurchaseRequest;
	
	@Column(name="ID_TRANSPORT_AUCTION_STATUS")
	private long IdTransportAuctionStatus;
	
	@Column(name="CREATION_DATE")
	private LocalDateTime CreationDate;
	
	@Column(name="UPDATE_DATE")
	private LocalDateTime UpdateDate;
	
    @JoinColumn(name="ID_PURCHASE_REQUEST", referencedColumnName="ID", insertable=false, updatable=false)
    @ManyToOne(fetch=FetchType.LAZY)
	private PurchaseRequest PurchaseRequest;
    
    @JoinColumn(name="ID_TRANSPORT_AUCTION_STATUS", referencedColumnName="ID", insertable=false, updatable=false)
    @ManyToOne(fetch=FetchType.LAZY)
	private TransportAuction TransportAuction;

	public TransportAuction() {
	}
    
	public TransportAuction(long id) {
		Id = id;
	}

	public TransportAuction(long id, long idPurchaseRequest, long idTransportAuctionStatus, LocalDateTime creationDate,
			LocalDateTime updateDate, cl.virtualfair.models.virtualfair.PurchaseRequest purchaseRequest,
			TransportAuction transportAuction) {
		Id = id;
		IdPurchaseRequest = idPurchaseRequest;
		IdTransportAuctionStatus = idTransportAuctionStatus;
		CreationDate = creationDate;
		UpdateDate = updateDate;
		PurchaseRequest = purchaseRequest;
		TransportAuction = transportAuction;
	}

	public long getId() {
		return Id;
	}

	public void setId(long id) {
		Id = id;
	}

	public long getIdPurchaseRequest() {
		return IdPurchaseRequest;
	}

	public void setIdPurchaseRequest(long idPurchaseRequest) {
		IdPurchaseRequest = idPurchaseRequest;
	}

	public long getIdTransportAuctionStatus() {
		return IdTransportAuctionStatus;
	}

	public void setIdTransportAuctionStatus(long idTransportAuctionStatus) {
		IdTransportAuctionStatus = idTransportAuctionStatus;
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

	public PurchaseRequest getPurchaseRequest() {
		return PurchaseRequest;
	}

	public void setPurchaseRequest(PurchaseRequest purchaseRequest) {
		PurchaseRequest = purchaseRequest;
	}

	public TransportAuction getTransportAuction() {
		return TransportAuction;
	}

	public void setTransportAuction(TransportAuction transportAuction) {
		TransportAuction = transportAuction;
	}
}
