/*
DROP TABLE test_case;
DROP TABLE contest;
*/


CREATE TABLE contest
(
    contest_id BIGSERIAL NOT NULL,
    public_id char(36) NOT NULL,
    problem_description TEXT NOT NULL,
    startup_project TEXT NOT NULL,
    CONSTRAINT pk_contest PRIMARY KEY (contest_id)
);

CREATE UNIQUE INDEX udx_contest_public_id ON contest(public_id);

CREATE TABLE test_case
(
    test_case_id BIGSERIAL NOT NULL,
    contest_id BIGINT NOT NULL,
    ord INT NOT NULL,
    timeout INT NOT NULL DEFAULT 30000, --In milliseconds
    input TEXT NOT NULL,
    output TEXT NOT NULL,
    CONSTRAINT pk_test_case PRIMARY KEY (test_case_id),
    CONSTRAINT fk_test_case_contest FOREIGN KEY (contest_id) 
	REFERENCES contest(contest_id)
);

CREATE INDEX idx_test_case_contest_id ON test_case(contest_id);
CREATE UNIQUE INDEX udx_test_case_test_ord ON test_case(contest_id, ord);