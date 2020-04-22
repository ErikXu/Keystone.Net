FROM centos:centos7.6.1810

ADD . /tmp

RUN \
      mv -f /tmp/epel.repo /etc/yum.repos.d && \
      mv -f /tmp/httpd-foreground /usr/bin && \
      chmod +x /usr/bin/httpd-foreground && \
      \cp /usr/share/zoneinfo/Asia/Shanghai /etc/localtime && \
      yum clean all && \
      yum makecache && \
      yum install centos-release-openstack-train.noarch -y && \
      yum install openstack-keystone httpd mod_wsgi -y && \
      mv -f /tmp/httpd.conf /etc/httpd/conf && \
      mv -f /tmp/wsgi-keystone.conf /etc/httpd/conf.d


EXPOSE 5000

CMD ["/usr/bin/sh","-c","httpd-foreground"]




