
CREATE TABLE public."Products"
(
    id uuid NOT NULL,
    "Name" text NOT NULL,
    PRIMARY KEY (id)
);
ALTER TABLE IF EXISTS public."Products"
    OWNER to postgres;


CREATE TABLE public."Pharmacy"
(
    id uuid NOT NULL,
    "Name" text NOT NULL,
    "Address" text NOT NULL,
    "Phone" text,
    PRIMARY KEY (id)
);
ALTER TABLE IF EXISTS public."Pharmacy"
    OWNER to postgres;


CREATE TABLE public."Storage"
(
    id uuid NOT NULL,
    "Pharmacy_id" uuid NOT NULL,
    "Name" text NOT NULL,
    PRIMARY KEY (id),
    CONSTRAINT "Pharmacy" FOREIGN KEY ("Pharmacy_id")
        REFERENCES public."Pharmacy" (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
        NOT VALID
);
ALTER TABLE IF EXISTS public."Storage"
    OWNER to postgres;


CREATE TABLE public."Batch"
(
    id uuid NOT NULL,
    "Product_id" uuid NOT NULL,
    "Storage_id" uuid NOT NULL,
    "Count" integer NOT NULL,
    PRIMARY KEY (id),
    CONSTRAINT "Products" FOREIGN KEY ("Product_id")
        REFERENCES public."Products" (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
        NOT VALID,
    CONSTRAINT "Storage" FOREIGN KEY ("Storage_id")
        REFERENCES public."Storage" (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
        NOT VALID
);
ALTER TABLE IF EXISTS public."Batch"
    OWNER to postgres;