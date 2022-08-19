
CREATE TABLE conversion_rates(
 id BIGSERIAL PRIMARY KEY ,
 source varchar(15) NOT NULL,
 target varchar(15) NOT NULL,
 value double precision NOT NULL
);


create index "ix_conversion_rates_source"
    on conversion_rates (source);

create index "ix_conversion_rates_target"
    on conversion_rates (target);


INSERT INTO conversion_rates
(source, target, value)
VALUES
('c','f',1.8),
('f','c',1.8),
('mm','in',0.0394),
('in','mm',25.40),
('in','cm',2.54),
('cm','in',0.3937),
('ft','m',0.3048),
('m','ft',3.2809),
('km','mi',0.6214),
('mi','km',1.6093);

