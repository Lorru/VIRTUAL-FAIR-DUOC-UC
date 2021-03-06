DROP TABLE "VIRTUAL_FAIR"."SESSION_TOKEN";
DROP TABLE "VIRTUAL_FAIR"."EVENT_LOG";
DROP TABLE "VIRTUAL_FAIR"."EVENT_TYPE";
DROP TABLE "VIRTUAL_FAIR"."TRANSPORT_AUCTION_CARRIER";
DROP TABLE "VIRTUAL_FAIR"."TRANSPORT_AUCTION";
DROP TABLE "VIRTUAL_FAIR"."PURCHASE_REQUEST_PRODUCER";
DROP TABLE "VIRTUAL_FAIR"."PURCHASE_REQUEST_PRODUCT";
DROP TABLE "VIRTUAL_FAIR"."PRODUCT";
DROP TABLE "VIRTUAL_FAIR"."PURCHASE_REQUEST_REMARK";
DROP TABLE "VIRTUAL_FAIR"."PURCHASE_REQUEST";
DROP TABLE "VIRTUAL_FAIR"."PURCHASE_REQUEST_TYPE";
DROP TABLE "VIRTUAL_FAIR"."PURCHASE_REQUEST_STATUS";
DROP TABLE "VIRTUAL_FAIR"."CONTRACT";
DROP TABLE "VIRTUAL_FAIR"."USER";
DROP TABLE "VIRTUAL_FAIR"."PROFILE";

DROP SEQUENCE "VIRTUAL_FAIR"."SESSION_TOKEN_SEQ";
DROP SEQUENCE "VIRTUAL_FAIR"."EVENT_LOG_SEQ";
DROP SEQUENCE "VIRTUAL_FAIR"."EVENT_TYPE_SEQ";
DROP SEQUENCE "VIRTUAL_FAIR"."TRANSPORT_AUCTION_CARRIER_SEQ";
DROP SEQUENCE "VIRTUAL_FAIR"."TRANSPORT_AUCTION_SEQ";
DROP SEQUENCE "VIRTUAL_FAIR"."PURCHASE_REQUEST_PRODUCER_SEQ";
DROP SEQUENCE "VIRTUAL_FAIR"."PURCHASE_REQUEST_PRODUCT_SEQ";
DROP SEQUENCE "VIRTUAL_FAIR"."PRODUCT_SEQ";
DROP SEQUENCE "VIRTUAL_FAIR"."PURCHASE_REQUEST_REMARK_SEQ";
DROP SEQUENCE "VIRTUAL_FAIR"."PURCHASE_REQUEST_SEQ";
DROP SEQUENCE "VIRTUAL_FAIR"."PURCHASE_REQUEST_TYPE_SEQ";
DROP SEQUENCE "VIRTUAL_FAIR"."PURCHASE_REQUEST_STATUS_SEQ";
DROP SEQUENCE "VIRTUAL_FAIR"."CONTRACT_SEQ";
DROP SEQUENCE "VIRTUAL_FAIR"."USER_SEQ";
DROP SEQUENCE "VIRTUAL_FAIR"."PROFILE_SEQ";

CREATE SEQUENCE "VIRTUAL_FAIR"."SESSION_TOKEN_SEQ" MINVALUE 1 MAXVALUE 9999999999 INCREMENT BY 1;
CREATE SEQUENCE "VIRTUAL_FAIR"."EVENT_LOG_SEQ" MINVALUE 1 MAXVALUE 9999999999 INCREMENT BY 1;
CREATE SEQUENCE "VIRTUAL_FAIR"."EVENT_TYPE_SEQ" MINVALUE 1 MAXVALUE 9999999999 INCREMENT BY 1;
CREATE SEQUENCE "VIRTUAL_FAIR"."TRANSPORT_AUCTION_CARRIER_SEQ" MINVALUE 1 MAXVALUE 9999999999 INCREMENT BY 1;
CREATE SEQUENCE "VIRTUAL_FAIR"."TRANSPORT_AUCTION_SEQ" MINVALUE 1 MAXVALUE 9999999999 INCREMENT BY 1;
CREATE SEQUENCE "VIRTUAL_FAIR"."PURCHASE_REQUEST_PRODUCER_SEQ" MINVALUE 1 MAXVALUE 9999999999 INCREMENT BY 1;
CREATE SEQUENCE "VIRTUAL_FAIR"."PURCHASE_REQUEST_PRODUCT_SEQ" MINVALUE 1 MAXVALUE 9999999999 INCREMENT BY 1;
CREATE SEQUENCE "VIRTUAL_FAIR"."PRODUCT_SEQ" MINVALUE 1 MAXVALUE 9999999999 INCREMENT BY 1;
CREATE SEQUENCE "VIRTUAL_FAIR"."PURCHASE_REQUEST_REMARK_SEQ" MINVALUE 1 MAXVALUE 9999999999 INCREMENT BY 1;
CREATE SEQUENCE "VIRTUAL_FAIR"."PURCHASE_REQUEST_SEQ" MINVALUE 1 MAXVALUE 9999999999 INCREMENT BY 1;
CREATE SEQUENCE "VIRTUAL_FAIR"."PURCHASE_REQUEST_TYPE_SEQ" MINVALUE 1 MAXVALUE 9999999999 INCREMENT BY 1;
CREATE SEQUENCE "VIRTUAL_FAIR"."PURCHASE_REQUEST_STATUS_SEQ" MINVALUE 1 MAXVALUE 9999999999 INCREMENT BY 1;
CREATE SEQUENCE "VIRTUAL_FAIR"."CONTRACT_SEQ" MINVALUE 1 MAXVALUE 9999999999 INCREMENT BY 1;
CREATE SEQUENCE "VIRTUAL_FAIR"."USER_SEQ" MINVALUE 1 MAXVALUE 9999999999 INCREMENT BY 1;
CREATE SEQUENCE "VIRTUAL_FAIR"."PROFILE_SEQ" MINVALUE 1 MAXVALUE 9999999999 INCREMENT BY 1;

CREATE TABLE "VIRTUAL_FAIR"."PROFILE"(
ID NUMBER(10) NOT NULL,
NAME VARCHAR(50) NOT NULL,
PRIMARY KEY(ID)
);

CREATE TABLE "VIRTUAL_FAIR"."USER"(
ID NUMBER(10) NOT NULL,
ID_PROFILE NUMBER(10) NOT NULL,
FULL_NAME VARCHAR(50) NOT NULL,
COUNTRY VARCHAR(50) NOT NULL,
CITY VARCHAR(50) NOT NULL,
ADDRESS VARCHAR(50) NOT NULL,
EMAIL VARCHAR(50) NOT NULL,
PASSWORD VARCHAR2(200) NOT NULL,
STATUS NUMBER(1) NOT NULL,
PRIMARY KEY(ID),
FOREIGN KEY(ID_PROFILE) REFERENCES "VIRTUAL_FAIR"."PROFILE"(ID)
);

CREATE TABLE "VIRTUAL_FAIR"."CONTRACT"(
ID NUMBER(10) NOT NULL,
ID_USER NUMBER(10) NOT NULL,
CREATION_DATE DATE NOT NULL,
EXPIRATION_DATE DATE NOT NULL,
IS_VALID NUMBER(1) NOT NULL,
PRIMARY KEY(ID),
FOREIGN KEY(ID_USER) REFERENCES "VIRTUAL_FAIR"."USER"(ID)
);

CREATE TABLE "VIRTUAL_FAIR"."PURCHASE_REQUEST_TYPE"(
ID NUMBER(10) NOT NULL,
NAME VARCHAR(50) NOT NULL,
PRIMARY KEY(ID)
);

CREATE TABLE "VIRTUAL_FAIR"."PURCHASE_REQUEST_STATUS"(
ID NUMBER(10) NOT NULL,
NAME VARCHAR(50) NOT NULL,
PRIMARY KEY(ID)
);

CREATE TABLE "VIRTUAL_FAIR"."PURCHASE_REQUEST"(
ID NUMBER(10) NOT NULL,
ID_PURCHASE_REQUEST_TYPE NUMBER(10) NOT NULL,
ID_PURCHASE_REQUEST_STATUS NUMBER(10) NOT NULL,
ID_CLIENT NUMBER(10) NOT NULL,
TOTAL_WEIGHT NUMBER(10, 5) NULL,
TOTAL_PRICE NUMBER(10) NULL,
DESIRED_DATE DATE NOT NULL,
CREATION_DATE DATE NOT NULL,
UPDATE_DATE DATE NOT NULL,
IS_PUBLIC NUMBER(1) NULL,
PRIMARY KEY(ID),
FOREIGN KEY(ID_CLIENT) REFERENCES "VIRTUAL_FAIR"."USER"(ID),
FOREIGN KEY(ID_PURCHASE_REQUEST_TYPE) REFERENCES "VIRTUAL_FAIR"."PURCHASE_REQUEST_TYPE"(ID),
FOREIGN KEY(ID_PURCHASE_REQUEST_STATUS) REFERENCES "VIRTUAL_FAIR"."PURCHASE_REQUEST_STATUS"(ID)
);

CREATE TABLE "VIRTUAL_FAIR"."PURCHASE_REQUEST_REMARK"(
ID NUMBER(10) NOT NULL,
ID_PURCHASE_REQUEST_STATUS NUMBER(10) NOT NULL,
ID_PURCHASE_REQUEST NUMBER(10) NOT NULL,
REMARK VARCHAR2(1000) NULL, 
PRIMARY KEY(ID),
FOREIGN KEY(ID_PURCHASE_REQUEST_STATUS) REFERENCES "VIRTUAL_FAIR"."PURCHASE_REQUEST_STATUS"(ID),
FOREIGN KEY(ID_PURCHASE_REQUEST) REFERENCES "VIRTUAL_FAIR"."PURCHASE_REQUEST"(ID)
);

CREATE TABLE "VIRTUAL_FAIR"."PRODUCT"(
ID NUMBER(10) NOT NULL,
NAME VARCHAR(50) NOT NULL,
PRIMARY KEY(ID)
);

CREATE TABLE "VIRTUAL_FAIR"."PURCHASE_REQUEST_PRODUCT"(
ID NUMBER(10) NOT NULL,
ID_PURCHASE_REQUEST NUMBER(10) NOT NULL,
ID_PRODUCT NUMBER(10) NOT NULL,
WEIGHT NUMBER(10, 5) NOT NULL,
REMARK VARCHAR2(1000) NULL,
AGREED_PRICE NUMBER(10) NULL,
REQUIRES_REFRIGERATION NUMBER(1) NOT NULL,
PRIMARY KEY(ID),
FOREIGN KEY(ID_PURCHASE_REQUEST) REFERENCES "VIRTUAL_FAIR"."PURCHASE_REQUEST"(ID),
FOREIGN KEY(ID_PRODUCT) REFERENCES "VIRTUAL_FAIR"."PRODUCT"(ID)     
);

CREATE TABLE "VIRTUAL_FAIR"."PURCHASE_REQUEST_PRODUCER"(
ID NUMBER(10) NOT NULL,
ID_PURCHASE_REQUEST_PRODUCT NUMBER(10) NOT NULL,
ID_PRODUCER NUMBER(10) NOT NULL,
WEIGHT NUMBER(10, 5) NOT NULL,
PRICE NUMBER(10) NOT NULL,
EXPIRATION_DATE DATE NULL,
IS_PARTICIPANT NUMBER(1) NULL,
PRIMARY KEY(ID),
FOREIGN KEY(ID_PURCHASE_REQUEST_PRODUCT) REFERENCES "VIRTUAL_FAIR"."PURCHASE_REQUEST_PRODUCT"(ID),
FOREIGN KEY(ID_PRODUCER) REFERENCES "VIRTUAL_FAIR"."USER"(ID)
);

CREATE TABLE "VIRTUAL_FAIR"."TRANSPORT_AUCTION"(
ID NUMBER(10) NOT NULL,
ID_PURCHASE_REQUEST NUMBER(10) NOT NULL,
DESIRED_DATE DATE NOT NULL,
CREATION_DATE DATE NOT NULL,
UPDATE_DATE DATE NOT NULL,
IS_PUBLIC NUMBER(1) NULL,
PRIMARY KEY(ID),
FOREIGN KEY(ID_PURCHASE_REQUEST) REFERENCES "VIRTUAL_FAIR"."PURCHASE_REQUEST"(ID)
);

CREATE TABLE "VIRTUAL_FAIR"."TRANSPORT_AUCTION_CARRIER"(
ID NUMBER(10) NOT NULL,
ID_TRANSPORT_AUCTION NUMBER(10) NOT NULL,
ID_CARRIER NUMBER(10) NOT NULL,
PRICE NUMBER(10) NOT NULL,
IS_PARTICIPANT NUMBER(1) NULL,
PRIMARY KEY(ID),
FOREIGN KEY(ID_TRANSPORT_AUCTION) REFERENCES "VIRTUAL_FAIR"."TRANSPORT_AUCTION"(ID),
FOREIGN KEY(ID_CARRIER) REFERENCES "VIRTUAL_FAIR"."USER"(ID)
);

CREATE TABLE "VIRTUAL_FAIR"."EVENT_TYPE"(
ID NUMBER(10) NOT NULL,
NAME VARCHAR(50) NOT NULL,
PRIMARY KEY(ID)
);

CREATE TABLE "VIRTUAL_FAIR"."EVENT_LOG"(
ID NUMBER(10) NOT NULL,
ID_EVENT_TYPE NUMBER(10) NOT NULL,
ID_USER NUMBER(10) NULL,
CONTROLLER VARCHAR(50) NOT NULL,
METHOD VARCHAR(100) NOT NULL,
HTTP_METHOD VARCHAR(50) NOT NULL,
HOST VARCHAR(50) NOT NULL,
MESSAGE VARCHAR2(1000) NULL,
EVENT_DATE DATE NOT NULL,
PRIMARY KEY(ID),
FOREIGN KEY(ID_EVENT_TYPE) REFERENCES "VIRTUAL_FAIR"."EVENT_TYPE"(ID),
FOREIGN KEY(ID_USER) REFERENCES "VIRTUAL_FAIR"."USER"(ID)
);

CREATE TABLE "VIRTUAL_FAIR"."SESSION_TOKEN"(
ID NUMBER(10) NOT NULL,
ID_USER NUMBER(10) NOT NULL,
TOKEN VARCHAR2(1000) NOT NULL,
HOST VARCHAR(50) NOT NULL,
CREATION_DATE DATE NOT NULL,
EXPIRATION_DATE DATE NOT NULL,
PRIMARY KEY(ID),
FOREIGN KEY(ID_USER) REFERENCES "VIRTUAL_FAIR"."USER"(ID)
);

INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'AJO');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'ACELGA');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'AGUACATE');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'ESPINACA');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'BERROS');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'CALABAZA');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'CALABACIN');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'CEBOLLA');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'COLIFLOR');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'BROCOLI');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'COL');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'GUISANTES');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'JUDIAS VERDES');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'LECHUGA');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'ESCAROLA');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'ENDIBIAS');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'PATATAS');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'PIMIENTOS');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'TOMATES');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'ZANAHORIAS');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'ARANDANOS');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'CAQUI');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'CIRUELAS');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'FRAMBUESAS');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'FRESAS');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'GRANADA');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'HIGOS');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'KIWI');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'LIMON');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'MANDARINA');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'MANGO');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'MANZANA');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'MELON');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'NARANJA');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'PERA');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'PIÑA');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'PLATANO');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'SANDIA');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'PAPAYA');
INSERT INTO "VIRTUAL_FAIR"."PRODUCT" (ID, NAME) VALUES (PRODUCT_SEQ.NEXTVAL, 'UVA');

INSERT INTO "VIRTUAL_FAIR"."PURCHASE_REQUEST_STATUS" (ID, NAME) VALUES(PURCHASE_REQUEST_STATUS_SEQ.NEXTVAL, 'SOLICITADO');
INSERT INTO "VIRTUAL_FAIR"."PURCHASE_REQUEST_STATUS" (ID, NAME) VALUES(PURCHASE_REQUEST_STATUS_SEQ.NEXTVAL, 'RECHAZADO POR EL ADMINISTRADO');
INSERT INTO "VIRTUAL_FAIR"."PURCHASE_REQUEST_STATUS" (ID, NAME) VALUES(PURCHASE_REQUEST_STATUS_SEQ.NEXTVAL, 'EN RECOLECCIÓN DE PRODUCTOS');
INSERT INTO "VIRTUAL_FAIR"."PURCHASE_REQUEST_STATUS" (ID, NAME) VALUES(PURCHASE_REQUEST_STATUS_SEQ.NEXTVAL, 'EN SUBASTA DE TRANSPORTE');
INSERT INTO "VIRTUAL_FAIR"."PURCHASE_REQUEST_STATUS" (ID, NAME) VALUES(PURCHASE_REQUEST_STATUS_SEQ.NEXTVAL, 'EN BODEGA');
INSERT INTO "VIRTUAL_FAIR"."PURCHASE_REQUEST_STATUS" (ID, NAME) VALUES(PURCHASE_REQUEST_STATUS_SEQ.NEXTVAL, 'EN CAMINO');
INSERT INTO "VIRTUAL_FAIR"."PURCHASE_REQUEST_STATUS" (ID, NAME) VALUES(PURCHASE_REQUEST_STATUS_SEQ.NEXTVAL, 'ENTREGADO');
INSERT INTO "VIRTUAL_FAIR"."PURCHASE_REQUEST_STATUS" (ID, NAME) VALUES(PURCHASE_REQUEST_STATUS_SEQ.NEXTVAL, 'ACEPTADO POR EL CLIENTE');
INSERT INTO "VIRTUAL_FAIR"."PURCHASE_REQUEST_STATUS" (ID, NAME) VALUES(PURCHASE_REQUEST_STATUS_SEQ.NEXTVAL, 'RECHAZADO POR EL CLIENTE');
INSERT INTO "VIRTUAL_FAIR"."PURCHASE_REQUEST_STATUS" (ID, NAME) VALUES(PURCHASE_REQUEST_STATUS_SEQ.NEXTVAL, 'PRECIO EN NEGOCIACIÓN');
INSERT INTO "VIRTUAL_FAIR"."PURCHASE_REQUEST_STATUS" (ID, NAME) VALUES(PURCHASE_REQUEST_STATUS_SEQ.NEXTVAL, 'PRECIO ACEPTADO');
INSERT INTO "VIRTUAL_FAIR"."PURCHASE_REQUEST_STATUS" (ID, NAME) VALUES(PURCHASE_REQUEST_STATUS_SEQ.NEXTVAL, 'PRECIO RECHAZADO');

INSERT INTO "VIRTUAL_FAIR"."PURCHASE_REQUEST_TYPE" (ID, NAME) VALUES(PURCHASE_REQUEST_TYPE_SEQ.NEXTVAL, 'LOCAL');
INSERT INTO "VIRTUAL_FAIR"."PURCHASE_REQUEST_TYPE" (ID, NAME) VALUES(PURCHASE_REQUEST_TYPE_SEQ.NEXTVAL, 'EXTRANJERO');

INSERT INTO "VIRTUAL_FAIR"."EVENT_TYPE" (ID, NAME) VALUES(EVENT_TYPE_SEQ.NEXTVAL, 'EVENT');
INSERT INTO "VIRTUAL_FAIR"."EVENT_TYPE" (ID, NAME) VALUES(EVENT_TYPE_SEQ.NEXTVAL, 'EXCEPTION');

INSERT INTO "VIRTUAL_FAIR"."PROFILE" (ID, NAME) VALUES(PROFILE_SEQ.NEXTVAL, 'ADMINISTRADOR');
INSERT INTO "VIRTUAL_FAIR"."PROFILE" (ID, NAME) VALUES(PROFILE_SEQ.NEXTVAL, 'CONSULTOR');
INSERT INTO "VIRTUAL_FAIR"."PROFILE" (ID, NAME) VALUES(PROFILE_SEQ.NEXTVAL, 'PRODUCTOR');
INSERT INTO "VIRTUAL_FAIR"."PROFILE" (ID, NAME) VALUES(PROFILE_SEQ.NEXTVAL, 'TRANSPORTISTA');
INSERT INTO "VIRTUAL_FAIR"."PROFILE" (ID, NAME) VALUES(PROFILE_SEQ.NEXTVAL, 'CLIENTE INTERNO');
INSERT INTO "VIRTUAL_FAIR"."PROFILE" (ID, NAME) VALUES(PROFILE_SEQ.NEXTVAL, 'CLIENTE EXTERNO');

INSERT INTO "VIRTUAL_FAIR"."USER" (ID, ID_PROFILE, EMAIL, FULL_NAME, COUNTRY, CITY, ADDRESS, PASSWORD, STATUS) VALUES (USER_SEQ.NEXTVAL, '1', 'administrador@virtualfair.cl', 'Administrador', 'Chile', 'Santiago', 'Calle Falsa 123', 'eIdcM/gplI0ICqot8ks3lw==', '1');
INSERT INTO "VIRTUAL_FAIR"."USER" (ID, ID_PROFILE, EMAIL, FULL_NAME, COUNTRY, CITY, ADDRESS, PASSWORD, STATUS) VALUES (USER_SEQ.NEXTVAL, '2', 'consultor@virtualfair.cl', 'Consultor', 'Chile', 'Santiago', 'Calle Falsa 123', 'eIdcM/gplI0ICqot8ks3lw==', '1');
INSERT INTO "VIRTUAL_FAIR"."USER" (ID, ID_PROFILE, EMAIL, FULL_NAME, COUNTRY, CITY, ADDRESS, PASSWORD, STATUS) VALUES (USER_SEQ.NEXTVAL, '3', 'productor@virtualfair.cl', 'Productor', 'Chile', 'Santiago', 'Calle Falsa 123', 'eIdcM/gplI0ICqot8ks3lw==', '1');
INSERT INTO "VIRTUAL_FAIR"."USER" (ID, ID_PROFILE, EMAIL, FULL_NAME, COUNTRY, CITY, ADDRESS, PASSWORD, STATUS) VALUES (USER_SEQ.NEXTVAL, '4', 'transportista@virtualfair.cl', 'Transportista', 'Chile', 'Santiago', 'Calle Falsa 123', 'eIdcM/gplI0ICqot8ks3lw==', '1');
INSERT INTO "VIRTUAL_FAIR"."USER" (ID, ID_PROFILE, EMAIL, FULL_NAME, COUNTRY, CITY, ADDRESS, PASSWORD, STATUS) VALUES (USER_SEQ.NEXTVAL, '5', 'clienteinterno@virtualfair.cl', 'Cliente Interno', 'Chile', 'Santiago', 'Calle Falsa 123', 'eIdcM/gplI0ICqot8ks3lw==', '1');
INSERT INTO "VIRTUAL_FAIR"."USER" (ID, ID_PROFILE, EMAIL, FULL_NAME, COUNTRY, CITY, ADDRESS, PASSWORD, STATUS) VALUES (USER_SEQ.NEXTVAL, '6', 'clienteexterno@virtualfair.cl', 'Cliente Externo', 'Chile', 'Santiago', 'Calle Falsa 123', 'eIdcM/gplI0ICqot8ks3lw==', '1');

COMMIT;