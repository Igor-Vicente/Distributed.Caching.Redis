**Running the servers Redis and RedisInsight (Docker)**

```bash
git clone https://github.com/Igor-Vicente/Distributed.Caching.Redis.git
```

```bash
cd Distributed.Caching.Redis/docker
```

```bash
docker compose up -d
```

**Accessing RedisInsight:**

1.  **Open Browser:** Go to `http://localhost:5540`.
2.  **Connect to Redis:** In RedisInsight, create a new connection using `redis` as the host and `6379` as the port.

![Screenshot Connectioning redis-insight and redis](https://raw.githubusercontent.com/Igor-Vicente/Distributed.Caching.Redis/refs/heads/main/docker/conn_example.png)

# Distributed Cache

A distributed cache is a data storage system spread across multiple networked computers. It improves application performance and scalability by storing copies of frequently accessed data, reducing database load and latency. Redis is a popular choice for distributed caching due to its speed, data structures, and optional persistence.

# Memory Cache

A memory cache (or local cache) stores data in the local memory of a single process or server for fast access. It's simpler to set up than a distributed cache but has limited scalability and data loss occurs on failure. It's suitable for frequently accessed data within a single server or as a first-level cache.
