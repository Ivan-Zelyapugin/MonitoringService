CREATE TABLE IF NOT EXISTS devices (
    id      UUID PRIMARY KEY,
    name    TEXT NOT NULL,
    version TEXT NOT NULL
);