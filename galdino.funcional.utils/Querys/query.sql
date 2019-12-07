--Tabela de usuarios
CREATE TABLE tb_users
(
 user_id serial NOT NULL,
  str_name character varying(200),
  str_login character varying(100),
  str_description character varying(50),
  str_password character varying(100),
  company_id integer,
  str_email character varying(200),
  dh_dateinclusionregistration timestamp without time zone,
  active boolean,
  dh_datechangeregistration timestamp without time zone,
  CONSTRAINT tb_users_pkey PRIMARY KEY (user_id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE tb_users
  OWNER TO dbfuncional;

INSERT INTO tb_users(
             str_name, str_login, str_description, str_password, 
            company_id, str_email, dh_dateinclusionregistration, active, 
            dh_datechangeregistration)
    VALUES (?, ?, ?, ?, 
            ?, ?, ?, ?, 
            ?);

--Tabela de produtos
CREATE TABLE tb_produto(
	product_id serial PRIMARY KEY,
	str_name varchar(200),
	industry_id integer,
	d_price numeric,
	amount integer,
	dh_dateinclusionregistration timestamp,
	dh_datechangeregistration timestamp,
	active boolean
)
INSERT INTO tb_produto(
             str_name, industry_id, d_price, amount, dh_dateinclusionregistration, 
            dh_datechangeregistration, active)
    VALUES ( 'Fralda Pampers', 1, 48.9, 1.500, 'now()', 
            null, true);

INSERT INTO tb_produto(
             str_name, industry_id, d_price, amount, dh_dateinclusionregistration, 
            dh_datechangeregistration, active)
    VALUES ( 'Fralda Turma da Monica', 2, 44.9, 980, 'now()', 
            null, true);

-- Tabela de indistrias
CREATE TABLE tb_industry(
	industry_id serial PRIMARY KEY,
	str_name varchar(200),
	dh_dateinclusionregistration timestamp,
	dh_datechangeregistration timestamp,
	active boolean)

INSERT INTO tb_industry(
            str_name, dh_dateinclusionregistration, dh_datechangeregistration, 
            active)
    VALUES ( 'Euro Farma', 'now()', null, 
            true);

INSERT INTO tb_industry(
            str_name, dh_dateinclusionregistration, dh_datechangeregistration, 
            active)
    VALUES ( 'Farma Ultra', 'now()', null, 
            true);