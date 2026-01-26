CREATE TABLE IF NOT EXISTS activity_sessions (
    id          UUID PRIMARY KEY,
    device_id   UUID        NOT NULL REFERENCES devices(id) ON DELETE CASCADE,
    start_time  TIMESTAMP   NOT NULL,
    end_time    TIMESTAMP   NOT NULL
);